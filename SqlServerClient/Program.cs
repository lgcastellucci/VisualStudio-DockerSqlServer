using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace SqlServerClient
{
    class Program
    {
        public static string serverIPAddress = "sqlserver"; // IP do servidor SQL Server
        public static string serverPort = "1433"; // Porta do servidor SQL Server

        static void Main()
        {

            Console.WriteLine("Sistema iniciado");

            bool isPortOpen = IsPortOpen(serverIPAddress, Convert.ToInt32(serverPort));
            while (!isPortOpen)
            {
                Console.WriteLine("Falha ao conectar em " + serverIPAddress + ":" + serverPort + ", aguardando 5 segundo e tentando novamente...");
                Thread.Sleep(5000);
                isPortOpen = IsPortOpen(serverIPAddress, Convert.ToInt32(serverPort));
            }
            Console.WriteLine(serverIPAddress + ":" + serverPort + " está disponível.");

            Console.WriteLine(DateTime.Now);
            var banco = new BancoDeDados(serverIPAddress, serverPort);

            #region iniciando o timer
            bool lStopTimer = false;
            while (!lStopTimer)
            {
                Console.WriteLine("Data atual do SqlServer: " + banco.DataAtual());
                Thread.Sleep(1000);
            }
            #endregion


        }

        static bool IsPortOpen(string ipAddress, int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect(ipAddress, port);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    class BancoDeDados
    {
        private string serverIPAddress;
        private string serverPort;

        public BancoDeDados(string serverIPAddress, string serverPort)
        {
            this.serverIPAddress = serverIPAddress;
            this.serverPort = serverPort;
        }
        public string DataAtual()
        {
            // Connection string to your SQL Server database
            string databaseName = "OPERADORA_TESTE"; // Nome do banco de dados
            string username = "user_github"; // Nome do usuário
            string password = "UserSqlServer2019!"; // Senha do usuário
            string connectionString = $"Server={serverIPAddress},{serverPort};Database={databaseName};User Id={username};Password={password};";

            // SQL query
            string query = "SELECT GETDATE()DATA_ATUAL";

            try
            {
                // Create a connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a command to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and obtain a reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Read each row
                                while (reader.Read())
                                {
                                    if (reader["DATA_ATUAL"] != null)
                                        return reader["DATA_ATUAL"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";

        }
    }
}