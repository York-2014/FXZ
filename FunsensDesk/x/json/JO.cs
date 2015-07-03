using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using x.util;

namespace x.json
{
    public class JO
    {
        private JObject jo;

        public JO()
        {
            this.jo = new JObject();
        }

        public JO(string joString)
        {
            try
            {
                this.jo = JObject.Parse(joString);
            }
            catch (Exception e)
            {
            }
        }

        public JO(JObject jo)
        {
            this.jo = jo;
        }

        public bool isNull()
        {
            return null == this.jo;
        }

        public void put(string name, string value)
        {
            this.jo.Add(name, value);
        }

        public void put(string name, int value)
        {
            this.jo.Add(name, value);
        }

        public void put(string name, JO value)
        {
            this.jo.Add(name, value.getJObject());
        }

        public void put(string name, JA value)
        {
            this.jo.Add(name, value.getJArray());
        }

        public string getString(string name)
        {
            return this.getString(name, S.EMPTY);
        }

        public string getString(string name, string defaultValue)
        {
            try
            {
                string value = (string)this.jo.GetValue(name);
                /*byte[] b = Encoding.UTF8.GetBytes(value);
                string result = Encoding.Default.GetString(b);

                return result;*/
                return value;
            }
            catch(Exception e)
            {

            }

            return defaultValue;
        }

        public int getInt(string name)
        {
            return this.getInt(name, -1);
        }

        public int getInt(string name, int defaultValue)
        {
            try
            {
                int value = int.Parse((string)this.jo.GetValue(name));
                return value;
            }
            catch (Exception e)
            {

            }

            return defaultValue;
        }

        public double getdouble(string name)
        {
            return this.getdouble(name, -1);
        }

        public double getdouble(string name, double defaultValue)
        {
            try
            {
                double value = double.Parse((string)this.jo.GetValue(name));
                return value;
            }
            catch (Exception e)
            {

            }

            return defaultValue;
        }

        public DateTime getDateTime(string name)
        {
            try
            {
                string value = (string)this.jo.GetValue(name);
             
                DateTime date = Convert.ToDateTime(value);

                return date;
            }
            catch(Exception e)
            {

            }

            return DateTime.Now;
        }

        public JO getJO(string name)
        {
            if (null == this.jo)
                return null;

            try
            {
                JObject jObject = (JObject)this.jo.GetValue(name);
                JO jo = new JO(jObject);

                return jo;
            }
            catch(Exception e)
            {

            }

            return null;
        }

        public JA getJA(string name)
        {
            try
            {
                if (null == this.jo)
                    return null;

                JArray _ja = (JArray)this.jo.GetValue(name);
                JA ja = new JA(_ja);

                return ja;
            }
            catch(Exception e)
            {

            }

            return null;
        }

        public JObject getJObject()
        {
            return this.jo;
        }

        public string toString()
        {
            return this.jo.ToString();
        }
    }
}
