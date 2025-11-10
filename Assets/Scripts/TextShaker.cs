using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextShaker : MonoBehaviour
{
    public float amplitude = 0.5f;      // Intensité du tremblement vertical
    public float frequency = 25f;       // Vitesse d'oscillation

    private TMP_Text _textMesh;
    private TMP_TextInfo _textInfo;
    private Vector3[][] _originalVertices;
    private float[] _randomOffsets;      // Décalage aléatoire par lettre pour désynchroniser

    void Awake()
    {
        _textMesh = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        _textMesh.ForceMeshUpdate();
        _textInfo = _textMesh.textInfo;

        int charCount = _textInfo.characterCount;
        if (charCount == 0) return;

        // Si le texte a changé, on recalcule les positions de base
        if (_originalVertices == null || _originalVertices.Length < _textInfo.meshInfo.Length)
        {
            CacheOriginalVertices();
            _randomOffsets = new float[charCount];
            for (int i = 0; i < charCount; i++)
                _randomOffsets[i] = Random.Range(0f, 10f);
        }

        for (int i = 0; i < charCount; i++)
        {
            if (!_textInfo.characterInfo[i].isVisible)
                continue;

            int materialIndex = _textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = _textInfo.characterInfo[i].vertexIndex;

            Vector3[] vertices = _textInfo.meshInfo[materialIndex].vertices;

            float time = Time.time * frequency + _randomOffsets[i];
            float yOffset = Mathf.Sin(time) * amplitude;

            Vector3 offset = new Vector3(0, yOffset, 0);

            vertices[vertexIndex + 0] = _originalVertices[materialIndex][vertexIndex + 0] + offset;
            vertices[vertexIndex + 1] = _originalVertices[materialIndex][vertexIndex + 1] + offset;
            vertices[vertexIndex + 2] = _originalVertices[materialIndex][vertexIndex + 2] + offset;
            vertices[vertexIndex + 3] = _originalVertices[materialIndex][vertexIndex + 3] + offset;
        }

        for (int i = 0; i < _textInfo.meshInfo.Length; i++)
        {
            var meshInfo = _textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            _textMesh.UpdateGeometry(meshInfo.mesh, i);
        }
    }

    void CacheOriginalVertices()
    {
        _textMesh.ForceMeshUpdate();
        _textInfo = _textMesh.textInfo;
        _originalVertices = new Vector3[_textInfo.meshInfo.Length][];

        for (int i = 0; i < _textInfo.meshInfo.Length; i++)
        {
            _originalVertices[i] = _textInfo.meshInfo[i].vertices.Clone() as Vector3[];
        }
    }
}
