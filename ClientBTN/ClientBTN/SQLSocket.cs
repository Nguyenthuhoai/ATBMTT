using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ClientBTN
{
    public class SQLSocket
    {
        String IP = "127.0.0.1";
        int Port = 56000;

        public byte[] Gui(String query)
        {
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(IP);
            try
            {
                sk.Connect(ip, Port);
                if (sk.Connected)
                {
                    sk.Send(Encoding.UTF8.GetBytes(query + "<EOF>"));                  
                    List<byte> dlNhan = new List<byte>();
                    byte[] boDem = new byte[1024];
                    int dem = sk.Receive(boDem);
                    for (int i = 0; i < dem; i++)
                        dlNhan.Add(boDem[i]);
                    while (dem > 0)
                    {
                        boDem = new byte[1024];
                        dem = sk.Receive(boDem);
                        if (dem > 0)
                            for (int i = 0; i < dem; i++)
                                dlNhan.Add(boDem[i]);
                        else
                            break;
                    }
                    sk.Disconnect(false);
                    sk.Close();
                    return dlNhan.ToArray();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối đến server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Lỗi khi kết nối đến server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable SelectAll(string tableCode)
        {
            String query = tableCode + "*";
            byte[] dlNhan = Gui(query);
            if (dlNhan == null || dlNhan.Length == 0)
                return null;
            else
            {
                System.Runtime.Serialization.IFormatter fm =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.MemoryStream ms = new System.IO.MemoryStream(dlNhan);
                DataTable tb = (DataTable)fm.Deserialize(ms);
                return tb;
            }
        }

        public DataTable SelectWithCondition(string tableCode, string condition)
        {
            String query = tableCode + "*" + condition;
            byte[] dlNhan = Gui(query);
            if (dlNhan == null || dlNhan.Length == 0)
                return null;
            else
            {
                System.Runtime.Serialization.IFormatter fm =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.MemoryStream ms = new System.IO.MemoryStream(dlNhan);
                DataTable tb = (DataTable)fm.Deserialize(ms);
                return tb;
            }
        }


        public int Insert(string tableCode, string[] data)
        {   

            String query = "";
            for (int i = 0; i < data.Length; i++)
            {   
                if(i == 0)
                {
                    query += tableCode + "*" + data[i];
                }
                else
                {
                    query += data[i];
                }
                if (i < data.Length - 1)
                    query += ";";
            }
            byte[] dlNhan = Gui(query);
            if (dlNhan == null)
                return -1;
            else
            {
                String value = Encoding.UTF8.GetString(dlNhan);
                return int.Parse(value);
            }           
        }

        public int Update(string tableCode, int id, string[] data)
        {
            String query = tableCode + "*" + id.ToString() + ";";
            for (int i = 0; i < data.Length; i++)
            {
                query += data[i];
                if (i < data.Length - 1)
                    query += ";";
            }
            byte[] dlNhan = Gui(query);
            if (dlNhan == null)
                return -1;
            else
            {
                String value = Encoding.UTF8.GetString(dlNhan);
                return int.Parse(value);
            }
        }

        public int Delete(string tableCode, int id)
        {
            String query = tableCode + "*" + id.ToString();
            byte[] dlNhan = Gui(query);
            if (dlNhan == null)
                return -1;
            else
            {
                String value = Encoding.UTF8.GetString(dlNhan);
                return int.Parse(value);
            }
        }

        public int DeleteCondition(string tableCode, string dkien)
        {
            String query = tableCode + "*" + dkien.ToString();
            byte[] dlNhan = Gui(query);
            if (dlNhan == null)
                return -1;
            else
            {
                String value = Encoding.UTF8.GetString(dlNhan);
                return int.Parse(value);
            }
        }


    }
}
