using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using TagLib;
using System.Windows.Forms;

namespace Reproductor
{
    public class Cancion
    {
        #region Variables

        private TagLib.File archivo;    //Objeto que contiene todos las variables
        private MemoryStream memoria;
        private Image imagen;           //Una copia de la imagen de tapa
        LyricWiki.LyricWikiPortTypeClient consulta;
        LyricWiki.LyricsResult resultado;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get
            {
                return archivo.Tag.Title;
            }
            set
            {
                archivo.Tag.Title = value;
            }
        }

        public string Artista
        {
            get
            {
                if (archivo.Tag.FirstAlbumArtist == null || archivo.Tag.Artists == null)
                    return null;
                else
                    return archivo.Tag.FirstAlbumArtist;
            }
            set
            {
                archivo.Tag.AlbumArtists = new string[] { value };
            }
        }

        public string Album
        {
            get
            {
                return archivo.Tag.Album;
            }
            set
            {
                archivo.Tag.Album = value;
            }
        }

        public string Genero
        {
            get
            {
                if (archivo.Tag.FirstGenre == null || archivo.Tag.Genres == null)
                    return null;
                else
                    return archivo.Tag.FirstGenre;
            }
            set
            {
                archivo.Tag.Genres = new string[] { value };
            }
        }

        public uint Año
        {
            get
            {
                return archivo.Tag.Year;
            }
            set
            {
                archivo.Tag.Year =  value;
            }
        }

        public string Letra
        {
            get
            {
                return archivo.Tag.Lyrics;
            }
            set
            {
                archivo.Tag.Lyrics = value;
            }
        }

        public TimeSpan Duracion
        {
            get
            {
                return archivo.Properties.Duration;
            }
        }

        public string Ruta
        {
            get
            {
                return archivo.Name;
            }
        }

        public Image Imagen
        {
            get
            {
                return imagen;
            }
        }

        public uint NumeroDeCancion
        {
            get
            {
                return archivo.Tag.Track;
            }
            set
            {
                archivo.Tag.Track = value;
            }
        }

        #endregion

        #region Metodos

        public Cancion(string filePath)
        {
            consulta = new Reproductor.LyricWiki.LyricWikiPortTypeClient();
            resultado = new Reproductor.LyricWiki.LyricsResult();
            archivo = TagLib.File.Create(@filePath);
            if (Album == null)
                Album = "Desconocido";
            if (Año.ToString() == "0")
                Año = 0;
            if (NumeroDeCancion.ToString() == "0")
                NumeroDeCancion = 0;
            if (Artista == null)
                Artista = "Desconocido";
            if (Genero == null)
                Genero = "Desconocido";
            if(Nombre == null)
                Nombre = "Desconocido";
            try
            {
                memoria = new MemoryStream(archivo.Tag.Pictures[0].Data.Data);
                imagen = Image.FromStream(memoria);
            }
            catch (Exception)
            {
                imagen = Reproductor.Properties.Resources.SinTapa;
            }
            finally
            {
                if (memoria != null)
                    memoria.Close();
            }
        }

        public string GetLyrics()
        {
            resultado = consulta.getSong(archivo.Tag.FirstAlbumArtist, archivo.Tag.Title);

            return resultado.lyrics;
        }

        public string[] GetAlbumSongs()
        {
            string artist = archivo.Tag.FirstAlbumArtist;
            string song = archivo.Tag.Title;
            string direccion;
            string []lista;
            int año = (int)archivo.Tag.Year;

            consulta.getAlbum(ref artist, ref song, ref año, out direccion, out lista);

            return lista;
        }

        #endregion
    }
}
