using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Tv
    {
        private string _tvID;
        private string _panel;
        private int? _pantalla;
        private string _resolucion;
        private string _hdreadyfullhd;      
        private bool? _tdt;

        public string TvID { get => _tvID;
            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentOutOfRangeException("tvID no puede superar los 7 caracteres");
                }
                _tvID = value ?? throw new ArgumentNullException("tvID no puede ser nulo");
            }
        }

        public string Panel { get => _panel;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _panel = value;
                }
                else
                {
                    _panel = value.Length > 45 ? throw new ArgumentOutOfRangeException("Panel no puede superar los 45 caracteres") : value;
                }
                
            }
        }
        public int? Pantalla { get => _pantalla;
            set
            {
                _pantalla = value.ToString().Length > 6 ? throw new ArgumentOutOfRangeException("pantalla no puede superar los 6 caracteres") : value;
            }
        }
        public string Resolucion { get => _resolucion;
                set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _resolucion = value;
                }
                else
                {
                    _resolucion = value.Length > 15 ? throw new ArgumentOutOfRangeException("Resolucion no puede superar los 15 caracteres") : value;
                }

                
            }
        }
        public string Hdreadyfullhd { get => _hdreadyfullhd;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _hdreadyfullhd = value;
                }
                else
                {
                    _hdreadyfullhd = value.Length > 6 ? throw new ArgumentOutOfRangeException("hdreadyfullhd no puede superar los 6 caracteres") : value;
                }
              
            }
        }

        public bool? Tdt { get => _tdt; set => _tdt = value; }

     


        //constructor sin argumentos
        public Tv()
        {
            _tvID = "tvID";
            _panel = "panel";
            _pantalla = 0;
            _resolucion = "resolucion";
            _hdreadyfullhd = "hdreadyfullhd";
            _tdt =null;
        }

        //constructor con argumentos
        public Tv(string tvID, string panel, int? pantalla, string resolucion, string hdreadyfullhd, bool? tdt)
        {
            _tvID = tvID;
            _panel = panel;
            _pantalla = pantalla;
            _resolucion = resolucion;
            _hdreadyfullhd = hdreadyfullhd;
            _tdt =tdt ;
        }

        //constructor de copia
        public Tv(Tv otroTv)
        {
            _tvID = otroTv._tvID;
            _panel =otroTv._panel;
            _pantalla = otroTv._pantalla;
            _resolucion = otroTv._resolucion;
            _hdreadyfullhd = otroTv._hdreadyfullhd;
            _tdt = otroTv._tdt;
        }

        //destructor
        ~Tv()
        {
            _tvID = "";
            _panel = "";
            _pantalla = 0;
            _resolucion = "";
            _hdreadyfullhd = "";
            _tdt = null;
        }

        public override string ToString()
        {
            return TvID+"#"+Panel + "#"+Pantalla+"#"+Resolucion+"#"+Hdreadyfullhd+"#" +Tdt;
        }
    }
}
