using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Conti.Massimiliano._5I.XMLReadWrite
{
    public class Persona
    {
        public string Nome_C { get; set; }
        public string Cognome_C { get; set; }
        public string Indirizzo_C { get; set; }
        public string Number_C { get; set; }

        public Persona () { }

        public Persona(XElement e)
        {
            Nome_C = e.Attribute("Nome").Value;
            Cognome_C = e.Attribute("Cognome").Value;
            Indirizzo_C = e.Attribute("Indirizzo").Value;
            Number_C = e.Attribute("Numero").Value;
        }

        public Persona(string Nome, string Cogno, string Numb, string Indirizzo)
        {
            this.Nome_C = Nome;
            this.Cognome_C = Cogno;
            this.Number_C = Numb;
            this.Indirizzo_C = Indirizzo;
        }

        //////////////////////////////
        public XElement XML
        {
            get
            {
                return new XElement("Persona",
                        new XAttribute("Nome", Nome_C),
                        new XAttribute("Cognome", Cognome_C),
                        new XAttribute("Indirizzo", Indirizzo_C),
                        new XAttribute("Numero", Number_C)
                );
            }
        }
    }

    /// <divisione>
    /// ///////////////////////
    /// </divisione>
    public class Persone : List<Persona>
    {
        public string FileName { get; }

        public XElement XML
        {
            get
            {
                return new XElement(
                "Rubrica",
                    from item in this
                    select item.XML);
            }
        }

        public Persone(string fileName)
        {
            FileName = fileName;
            XElement Elements = XElement.Load(FileName);
            AddRange(
                from item in Elements.Elements("Persona")
                select new Persona(item)
            );
        }

        void Save()
        {
            XML.Save(FileName);
        }

        public void Aggiungi()
        {
            Add(
                new Persona
                {
                    Nome_C = "gsy",
                    Cognome_C = "geg",
                    Number_C = "3318077598",
                    Indirizzo_C = "via m. bruni"
                }
            );

            Save();
        }
    }
}