using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    internal class VideoGames
    {
        #region ENUMS

        public enum genres
        {
            strategy,
            rpg,
            racing,
            rhythm,
            action
        }

        #endregion ENUMS

        #region FIELDS

        private string _nameOfGame;
        private int _yearOfRelease;
        private bool _isRare;
        private genres _genre;

        #endregion FIELDS

        #region PROPERTIES

        public string NameOfGame
        {
            get { return _nameOfGame; }
            set { _nameOfGame = value; }
        }

        public int YearOfRelease
        {
            get { return _yearOfRelease; }
            set { _yearOfRelease = value; }
        }

        public bool IsRare
        {
            get { return _isRare; }
            set { _isRare = value; }
        }

        public genres Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        #endregion PROPERTIES
    }
}