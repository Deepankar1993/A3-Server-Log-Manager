using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace BackendManager.Utli
{
    class Packet
    {



        public static void WRITE(TcpClient client, byte[] sendData)
        {
            if (client.Connected)
            {
                NetworkStream ns = client.GetStream();
                ns.Write(sendData, 0, sendData.Length);
                ns.Flush();
            }

        }


        /// <summary>
        /// Takes the hex string and converts them to array of bytes 
        /// each hex should be seperated by <space>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] MakeBytesArrayfromHexString(string data)
        {
            string hex = data;
            string TrimHexString = hex.Trim();
            string[] stringHexArray = TrimHexString.Split(new char[] { ' ' });
            List<int> intList = new List<int>();

            //Convert to int array
            for (int i = 0; i < stringHexArray.Length; i++)
            {
                int k = Convert.ToInt32(stringHexArray[i], 16);
                intList.Add(k);
            }
            int[] intArray = intList.ToArray();

            byte[] bytes = intArray.Select(i => (byte)i).ToArray();
            return bytes;
        }



        /// <summary>
        /// Takes the integer string and converts them to array of bytes 
        /// each int should be seperated by <space>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] MakeBytesArrayfromIntString(string data, char seprator = ' ')
        {
            string hex = data;
            string TrimHexString = hex.Trim();
            string[] stringHexArray = TrimHexString.Split(seprator);
            List<int> intList = new List<int>();

            //Convert to int array
            //for (int i = 0; i < stringHexArray.Length; i++)
            //{
            //    int k = Convert.ToInt32(stringHexArray[i], 16);
            //    intList.Add(k);
            //}
            int[] intArray = stringHexArray.Select(int.Parse).ToArray(); ;

            byte[] bytes = intArray.Select(i => (byte)i).ToArray();
            return bytes;
        }

        /// <summary>
        /// Combining 2 byte array
        /// </summary>
        /// <param name="a">byte array 1</param>
        /// <param name="b">byte array 2</param>
        /// <returns>returns combined byte array (byte array 1 + byte array 2)</returns>
        public static byte[] CombineByteArray(byte[] a, byte[] b)
        {
            var c = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, c, 0, a.Length);
            Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }


        /// <summary>
        /// getting byte[] from string
        /// </summary>
        /// <param name="str">string data</param>
        /// <returns>byte[] obtained from string data</returns>
        public static byte[] GetBytesFrom(string str)
        {
            Byte[] bytes = Encoding.Default.GetBytes(str);
            return bytes;
        }

        /// <summary>
        /// Creating reverse byte[4] of int32 value
        /// </summary>
        /// <param name="num">int value</param>
        /// <returns>reverse byte[] of int value</returns>
        public static byte[] CreateReverseHexPacket(int num)
        {
            byte[] byteArray = BitConverter.GetBytes(num);
            return byteArray;
        }


        public static byte[] GetZeroHexPacket(int num)
        {
            string strZero = "0";
            for (int i = 0; i < num - 1; i++)
            {
                strZero = strZero + "," + "0";
            }
            byte[] zeroByteArray = MakeBytesArrayfromIntString(strZero, ',');
            return zeroByteArray;
        }


        /// <summary>
        /// Payement information when client clicks Check Payment Info.
        /// </summary>
        /// <param name="clientID">uniq id of client</param>
        /// <returns>payement information</returns>
        public static byte[] AS_Msg(string message)
        {
            byte[] packet = new byte[4];
            //packet = CreateReverseHexPacket(clientID);
            packet = CombineByteArray(packet, new byte[] { 0x03, 0xFF, 0x00, 0x18 });
            packet = CombineByteArray(packet, new byte[] { 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x53, 0x59, 0x53, 0x54, 0x45, 0x4D, 0x00, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0x00 });
            packet = CombineByteArray(packet, GetBytesFrom(message));
            int MsgLength = packet.Length - 34;
            MsgLength %= 4;
            // packet = CombineByteArray(packet, GetBytesFrom(GetNullString(4 - MsgLength)));
            //packet = CombineByteArray(CreateReverseHexPacket(packet.Length + 4), packet);
            //var tempBytes = Crypt.Encrypt(packet);
            return packet;
        }

        /// <summary>
        /// Payement information when client clicks Check Payment Info.
        /// </summary>
        /// <param name="clientID">uniq id of client</param>
        /// <returns>payement information</returns>
        public static byte[] PrivateMessage(int clientID, string message)
        {
            byte[] packet = new byte[4];
            packet = CreateReverseHexPacket(clientID);
            packet = CombineByteArray(packet, new byte[] { 0x03, 0xFF, 0x00, 0x18 });
            packet = CombineByteArray(packet, new byte[] { 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x53, 0x59, 0x53, 0x54, 0x45, 0x4D, 0x00, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0x00 });
            packet = CombineByteArray(packet, GetBytesFrom(message));
            int MsgLength = packet.Length - 34;
            MsgLength %= 4;
            // packet = CombineByteArray(packet, GetBytesFrom(GetNullString(4 - MsgLength)));
            packet = CombineByteArray(CreateReverseHexPacket(packet.Length + 4), packet);
            //var tempBytes = Crypt.Encrypt(packet);
            return packet;
        }
    }
}
