using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace x.json
{
    public class JA
    {
        private JArray ja;

        public JA()
        {
            this.ja = new JArray();
        }

        public JA(string jaString)
        {
            this.ja = (JArray)JsonConvert.DeserializeObject(jaString);
        }

        public JA(JArray ja)
        {
            this.ja = ja;
        }

        public int size()
        {
            return null == this.ja ? 0 : this.ja.Count;
        }

        public void put(JO jo)
        {
            this.ja.Add(jo.getJObject());
        }

        public string getString(int index)
        {
            try
            {
                string s = this.ja[index].ToString();

                return s;
            }
            catch(Exception e)
            {
            }

            return null;
        }

        public JO getJO(int index)
        {
            JObject _jo = (JObject)this.ja[index];
            JO jo = new JO(_jo);

            return jo;
        }

        public JO getJO(string name)
        {
            JObject _jo = (JObject)this.ja[name];
            JO jo = new JO(_jo);

            return jo;
        }

        public JArray getJArray()
        {
            return this.ja;
        }

        public string toString()
        {
            return this.ja.ToString();
        }
    }
}
