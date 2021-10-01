private static string RandomHexString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            //String is ready, convert to to HEX
            string randomString=builder.ToString();

            var resultHex = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(randomString);
            foreach (var t in bytes)
            {
                resultHex.Append(t.ToString("X2"));
            }
            return resultHex.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }  