using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Storage
{
    [Serializable]
    public class Film : StorageItem
    {
        public enum F_GENRE
        {
            Action,
            Adventure,
            Comedy,
            Crime_And_Mystery,
            Fantasy,
            Historical,
            Horror,
            Romance,
            Satire,
            Science_Fiction,
            Thriller,
            Western,
            Saga,
            Sport,
            Drama,
            Unscripted,
            Series,
            Fairytale
        }

        public bool tagsAllowed;

        private string duration;

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        private string tags;

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        public List<F_GENRE> genres;

        public Film(List<F_GENRE> _genres)
        {
            genres = _genres;
        }

        public Film(List<F_GENRE> _genres, string _id) : base(_id)
        {
            genres = _genres;
        }

        public override string GetGenres()
        {
            string genresString = "";
            foreach (F_GENRE fg in genres)
            {
                genresString += (genresString == "") ? GetGenre(fg) : ", " + GetGenre(fg);
            }
            return genresString;
        }

        public bool edited = false;

        private string GetGenre(F_GENRE genre)
        {
            switch (genre)
            {
                case F_GENRE.Action:
                    return "Action";
                case F_GENRE.Adventure:
                    return "Adventure";
                case F_GENRE.Comedy:
                    return "Comedy";
                case F_GENRE.Crime_And_Mystery:
                    return "Crime And Mystery";
                case F_GENRE.Drama:
                    return "Drama";
                case F_GENRE.Fantasy:
                    return "Fantasy";
                case F_GENRE.Historical:
                    return "Historical";
                case F_GENRE.Horror:
                    return "Horror";
                case F_GENRE.Romance:
                    return "Romance";
                case F_GENRE.Saga:
                    return "Saga";
                case F_GENRE.Satire:
                    return "Satire";
                case F_GENRE.Science_Fiction:
                    return "Science Fiction";
                case F_GENRE.Series:
                    return "Series";
                case F_GENRE.Sport:
                    return "Sport";
                case F_GENRE.Thriller:
                    return "Thriller";
                case F_GENRE.Unscripted:
                    return "Unscripted";
                case F_GENRE.Western:
                    return "Western";
                case F_GENRE.Fairytale:
                    return "Fairytale";
                default:
                    return "???";
            }
        }
    }
}
