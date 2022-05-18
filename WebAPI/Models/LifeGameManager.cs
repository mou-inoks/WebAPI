namespace WebAPI.Models
{
    public class LifeGameManager
    {
        public List<List<int>> TableInitialisation()
        {
            int defaultSize = 50;

            List<List<int>> tableau = new List<List<int>>() { };


            for (int i = 0; i < defaultSize; i++)
            {   
                var row = new List<int>();  
                for(int j = 0; j < defaultSize; j++)
                {
                    row.Add(0);
                }
                tableau.Add(row);
            }
            tableau[6][9] = 1;
            tableau[7][9] = 1;
            tableau[8][9] = 1;
            return tableau;
        }
        
        public List<List<int>> GenerateNextState(List<List<int>> currentTable, int index)
        {
            bool vie = false;
            var nextTable = currentTable;
            //First = row
            //Second = Columns
            if (currentTable[index - 1][index - 1] == 1 && currentTable[index - 1][index] == 1 && currentTable[index - 1][index + 1] == 1)
                vie = true;
            else if (currentTable[index - 1][index] == 1 && currentTable[index - 1][index + 1] == 1 && currentTable[index][index + 1] == 1)
                vie = true;
            else if (currentTable[index][index + 1] == 1 && currentTable[index + 1][index + 1] == 1 && currentTable[index + 1][index] == 1)
                vie = true;


            return nextTable;
        }
    }
}
