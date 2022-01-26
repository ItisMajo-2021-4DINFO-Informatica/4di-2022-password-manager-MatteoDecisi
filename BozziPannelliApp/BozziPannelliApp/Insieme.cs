using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BozziPannelliApp
{
    class Insieme
    {
        public List<Misura> ElencoMisure { get; set; }

        public Insieme()
        {
            ElencoMisure = new List<Misura>();
        }

        public void Aggiungi(Misura unNuovoElemento)
        {
            ElencoMisure.Add(unNuovoElemento);
        }

        public void LeggiDaFile(string nomeFile)
        {
            using (FileStream flussoDati = new FileStream(nomeFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader lettoreDati = new StreamReader(flussoDati))
                {
                    while (!lettoreDati.EndOfStream)
                    {
                        string linea = lettoreDati.ReadLine();
                        string[] campi = linea.Split('$');

                        Misura unaMisuraLettaDaFile = new Misura();

                        unaMisuraLettaDaFile.Tensione = float.Parse(campi[0]);
                        unaMisuraLettaDaFile.Corrente = float.Parse(campi[1]);
                        unaMisuraLettaDaFile.Ora = campi[2];
                        unaMisuraLettaDaFile.Minuti = campi[3];

                        Aggiungi(unaMisuraLettaDaFile);

                    }
                }
            }
        }
        public string CercaPotenzaMassima()
        {
            float max = float.MinValue;
            string orarioTrovato = "";
            foreach (var misura in ElencoMisure)
            {
                if (misura.Potenza() > max)
                {
                    max = misura.Potenza();
                    orarioTrovato = misura.Ora + ":" + misura.Minuti;
                }
            }

            return orarioTrovato;
        }
    }
}
