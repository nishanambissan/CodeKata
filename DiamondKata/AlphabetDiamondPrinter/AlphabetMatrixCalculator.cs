namespace AlphabetDiamondPrinter;

public partial class AlphabetMatrixCalculator
{
    private readonly Dictionary<string, int> _alphabetIndexLookup = new Dictionary<string, int>();
    private readonly Dictionary<int, string> _indexAlphabetLookup = new Dictionary<int, string>();

    public AlphabetMatrixCalculator()
    {
        InitialiseAlphabetLookupTable();
    }

    private void InitialiseAlphabetLookupTable()
    {
        var c = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        var key = 0;
        foreach (var value in c)
        {
            _alphabetIndexLookup.Add(value.ToString(), key);
            _indexAlphabetLookup.Add(key, value.ToString());
            key++;
        }
    }

    public RowInfo[] CalculateAlphabetMatrix(string inputAlphabet)
    {
        int n = _alphabetIndexLookup[inputAlphabet];
        var rowCount = n + 1;
        var resultMatrixRows = new RowInfo[rowCount];

        for (int i = 0; i < rowCount; i++)
        {
            if (i == 0)
            {
                resultMatrixRows[0] = new RowInfo {Index1 = n, Index2 = n, Alphabet = _indexAlphabetLookup[i]};
            }
            else
            {
                resultMatrixRows[i] = new RowInfo {Index1 = n - i, Index2 = n + i, Alphabet = _indexAlphabetLookup[i]};
            }
        }

        return resultMatrixRows;
    }
}