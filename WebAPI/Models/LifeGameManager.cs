using System.Linq;
namespace WebAPI.Models
{
    public class LifeGameManager
    {
        public void TableInitialisation(List<List<int>> current, List<List<int>> next)
        {
            int defaultSize = 50;

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
                //APPELER LA FORME

               
            }
        }

        public void Autre(List<List<int>> current, List<List<int>> next)
        {

        }
        public void Missile(List<List<int>> current, List<List<int>> next)
        {

            ///////////////////////
            ///    CURRENT      ///
            //////////////////////

            //Carré
            current[4][0] = 1;
            current[5][0] = 1;
            current[4][1] = 1;
            current[5][1] = 1;

            //Canon gauche 
            current[4][10] = 1;
            current[5][10] = 1;
            current[6][10] = 1;
            current[7][11] = 1;
            current[8][12] = 1;
            current[8][13] = 1;
            current[7][15] = 1;
            current[6][16] = 1;
            current[5][16] = 1;
            current[5][17] = 1;
            current[4][16] = 1;
            current[3][15] = 1;
            current[5][14] = 1;
            current[2][13] = 1;
            current[2][12] = 1;
            current[3][11] = 1;


            //canon milieu
            current[0][24] = 1;
            current[1][24] = 1;
            current[1][22] = 1;
            current[2][20] = 1;
            current[2][21] = 1;
            current[3][20] = 1;
            current[3][21] = 1;
            current[4][20] = 1;
            current[4][21] = 1;
            current[5][22] = 1;
            current[5][24] = 1;
            current[6][24] = 1;

            //Carré droit 
            current[2][35] = 1;
            current[2][34] = 1;
            current[3][35] = 1;
            current[2][34] = 1;



            ///////////////////////
            ///      NEXT       ///
            //////////////////////

            //Carré
            next[4][0] = 1;
            next[5][0] = 1;
            next[4][1] = 1;
            next[5][1] = 1;

            //Canon gauche 
            next[4][10] = 1;
            next[5][10] = 1;
            next[6][10] = 1;
            next[7][11] = 1;
            next[8][12] = 1;
            next[8][13] = 1;
            next[7][15] = 1;
            next[6][16] = 1;
            next[5][16] = 1;
            next[5][17] = 1;
            next[4][16] = 1;
            next[3][15] = 1;
            next[5][14] = 1;
            next[2][13] = 1;
            next[2][12] = 1;
            next[3][11] = 1;


            //canon milieu
            next[0][24] = 1;
            next[1][24] = 1;
            next[1][22] = 1;
            next[2][20] = 1;
            next[2][21] = 1;
            next[3][20] = 1;
            next[3][21] = 1;
            next[4][20] = 1;
            next[4][21] = 1;
            next[5][22] = 1;
            next[5][24] = 1;
            next[6][24] = 1;

            //Carré droit 
            next[2][35] = 1;
            next[2][34] = 1;
            next[3][35] = 1;
            next[2][34] = 1;
        }

        public void GenerateNextState(List<List<int>> currentTable, List<List<int>> nextTable, int avancementDegre)
        {
            //First = row
            //Second = Columns
            for(int l = 0; l < avancementDegre; l++)
            {
                currentTable = new List<List<int>>();
                for (int i = 0; i < nextTable.Count; i++)
                {
                    currentTable.Add(new List<int>(nextTable[i]));
                }

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
                        else if (i == currentTable.Count - 1 && j == 0)
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
} 

