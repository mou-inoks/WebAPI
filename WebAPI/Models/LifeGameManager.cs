using System.Linq;
namespace WebAPI.Models
{
    public class LifeGameManager
    {
        public void TableInitialisation(List<List<int>> current, List<List<int>> next)
        {
            int defaultSize = 20;

            if (current.Count > 0)
            {
                next = new List<List<int>>(current);
            }
            else {
                for (int i = 0; i < defaultSize; i++)
                {
                    var rowCurrent = new List<int>();
                    var rowNext = new List<int>();
                    for (int j = 0; j < defaultSize; j++)
                    {
                        rowCurrent.Add(0);
                        rowNext.Add(0);
                    }
                    current.Add(rowCurrent);
                    next.Add(rowNext);
                }

                current[2][4] = 1;
                current[3][4] = 1;
                current[4][4] = 1;

                next[2][4] = 1;
                next[3][4] = 1;
                next[4][4] = 1;
            }
        }

        public void GenerateNextState(List<List<int>> currentTable, List<List<int>> nextTable)
        {
            //First = row
            //Second = Columns
            for (int i = 0; i < currentTable.Count; i++)
            {
                for (int j = 0; j < currentTable.Count; j++)
                {
                    int counter = 0;
                    //Coin en haut a gauche ?
                    if (i == 0 && j == 0)
                    {
                        //en bas
                        if (currentTable[i + 1][j] == 1)
                            counter++;
                        //en bas a droite 
                        if (currentTable[i + 1][j + 1] == 1)
                            counter++;
                        //a droite 
                        if (currentTable[i][j + 1] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else 
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if(counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }
                    //Coin en haut a droite ? 
                    else if (i == 0 && j == currentTable.Count - 1)
                    {
                        //en bas
                        if (currentTable[i + 1][j] == 1)
                            counter++;
                        //en bas a gauche
                        if (currentTable[i + 1][j - 1] == 1)
                            counter++;
                        //a gauche
                        if (currentTable[i][j - 1] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }

                    //Coin en bas a gauche ?
                    else if (i == currentTable.Count - 1  && j == 0)
                    {
                        //en haut 
                        if (currentTable[i - 1][j] == 1)
                            counter++;
                        //en haut a droite 
                        if (currentTable[i - 1][j + 1] == 1)
                            counter++;
                        //a droite 
                        if (currentTable[i][j + 1] == 1)
                            counter++;
                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }

                    //Coin en bas a droite ?
                    else if (i == currentTable.Count - 1 && j == currentTable.Count - 1)
                    {
                        //en haut
                        if (currentTable[i - 1][j] == 1)
                            counter++;
                        //en haut a gauche
                        if (currentTable[i - 1][j - 1] == 1)
                            counter++;
                        //a gauche
                        if (currentTable[i][j - 1] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }

                    //I = Tout à gauche  ?
                    else if (j == 0)
                    {
                        //en haut 
                        if (currentTable[i - 1][j] == 1)
                            counter++;
                        //en haut a droite
                        if (currentTable[i - 1][j + 1] == 1)
                            counter++;
                        //a droite 
                        if (currentTable[i][j + 1] == 1)
                            counter++;
                        //en bas a droite
                        if (currentTable[i + 1][j + 1] == 1)
                            counter++;
                        //en bas 
                        if (currentTable[i + 1][j] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }

                    //I = Tout a droite ?
                    else if (j == currentTable.Count - 1)
                    {
                        //en haut 
                        if (currentTable[i - 1][j] == 1)
                            counter++;
                        //en haut a gauche
                        if (currentTable[i - 1][j - 1] == 1)
                            counter++;
                        //a gauche 
                        if (currentTable[i][j - 1] == 1)
                            counter++;
                        //en bas a gauche
                        if (currentTable[i + 1][j - 1] == 1)
                            counter++;
                        //en bas 
                        if (currentTable[i + 1][j] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }

                    //J = Tout en haut ? 
                    else if (i == 0)
                    {
                        //a gauche 
                        if (currentTable[i][j - 1] == 1)
                            counter++;
                        //en bas a gauche
                        if (currentTable[i + 1][j - 1] == 1)
                            counter++;
                        //en bas 
                       if (currentTable[i + 1][j] == 1)
                            counter++;
                        //en bas a droite
                        if (currentTable[i + 1][j + 1] == 1)
                            counter++;
                        //a droite
                        if (currentTable[i][j + 1] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }

                    //J = Tout en bas ? 
                    else if (i == currentTable.Count - 1)
                    {
                        //a droite 
                        if (currentTable[i][j + 1] == 1)
                            counter++;
                        //en haut a droite
                        if (currentTable[i - 1][j + 1] == 1)
                            counter++;
                        //en haut 
                        if (currentTable[i - 1][j] == 1)
                            counter++;
                        //en haut a gauche
                        if (currentTable[i - 1][j - 1] == 1)
                            counter++;
                        //a gauche
                        if (currentTable[i][j - 1] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }
                    else
                    {
                        //a droite 
                        if (currentTable[i][j + 1] == 1)
                            counter++;
                        //en haut a droite
                       if (currentTable[i - 1][j + 1] == 1)
                            counter++;
                        //en haut 
                        if (currentTable[i - 1][j] == 1)
                            counter++;
                        //en haut a gauche
                        if (currentTable[i - 1][j - 1] == 1)
                            counter++;
                        //a gauche
                        if (currentTable[i][j - 1] == 1)
                            counter++;
                        //en bas a droite
                        if (currentTable[i + 1][j + 1] == 1)
                            counter++;
                        //en bas 
                        if (currentTable[i + 1][j] == 1)
                            counter++;
                        //en bas a gauche
                        if (currentTable[i + 1][j - 1] == 1)
                            counter++;

                        if (currentTable[i][j] == 0)
                        {
                            if (counter == 3)
                                nextTable[i][j] = 1;
                            else
                                nextTable[i][j] = 0;
                        }
                        else if (currentTable[i][j] == 1)
                        {

                            if (counter == 2 || counter == 3)
                            {
                                nextTable[i][j] = 1;
                            }
                            else
                            {
                                nextTable[i][j] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
} 

