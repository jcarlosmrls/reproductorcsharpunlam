using System;
using System.Collections.Generic;
using System.Text;
using TagLib;

namespace Reproductor
{
    class Cancion
    {
        #region Variables

        private TagLib.File archivo;    //Objeto que contiene todos las variables

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
                return archivo.Tag.FirstAlbumArtist;
            }
            set
            {
                archivo.Tag.AlbumArtists[0] = value;
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
                return archivo.Tag.FirstGenre;
            }
            set
            {
                archivo.Tag.Genres[0] = value;
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

        #endregion

        #region Metodos

        public Cancion(string filePath)
        {
            archivo = TagLib.File.Create(filePath);
        }
        #endregion
    }
}
