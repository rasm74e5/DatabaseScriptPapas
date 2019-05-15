using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseScriptPapas
{
    public class Boardgame
    {
        public void InsertBoardgame()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();


                    SqlCommand command1 = new SqlCommand("INSERT INTO Game_Libary", con);
                    //Den nye SqlCommand er navnet på den StoredProcedure vi gerne vil køre;
                    command1.CommandType = CommandType.StoredProcedure;

                    string boardgameName = Console.ReadLine();
                    command1.Parameters.Add(new SqlParameter("@Boardgame_Name", boardgameName));

                    string numberOfPlayers = Console.ReadLine();
                    command1.Parameters.Add(new SqlParameter("@Player_Count", numberOfPlayers));

                    string audience = Console.ReadLine();
                    command1.Parameters.Add(new SqlParameter("@Audience", audience));

                    string expectedGameTime = Console.ReadLine();
                    command1.Parameters.Add(new SqlParameter("@Game_Time", expectedGameTime));

                    string distributor = Console.ReadLine();
                    command1.Parameters.Add(new SqlParameter("@Distributor", distributor));

                    string gameTag = Console.ReadLine();
                    command1.Parameters.Add(new SqlParameter("@GameTag", gameTag));

                    command1.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Fejl: " + e.Message);
                }
            }
        }
        public void GetBoardgame()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand command2 = new SqlCommand("ViewGameLibrary", con);
                    //ret Blabla til navnet på vores stored procedure GetBoardgame;
                    command2.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command2.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string boardgameName = reader["Boardgame_Name"].ToString();
                            string numberOfPlayers = reader["Player_Count"].ToString();
                            string audience = reader["Audience"].ToString();
                            string expectedGameTime = reader["Game_Time"].ToString();
                            string distributor = reader["Distributor"].ToString();
                            string boardgameId = reader["Boardgame_Id"].ToString();
                            string gameTag = reader["GameTag"].ToString();
                            Console.WriteLine($"\nBoardgame_Name: {boardgameName} \nPlayer_Count: {numberOfPlayers} \nAudience: {audience} " +
                            $"\nGame_Time: {expectedGameTime} \nDistributor: {distributor}\nBoardgame_Id: {boardgameId}\nGameTag {gameTag}\n");
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Fejl: " + e.Message);
                }
            }
        }
    }
}
