using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public sealed class Command
    {
        #region Attributs +  Prop's
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; set; }
        internal Dictionary<string, object> Parameters { get; set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Permet de créer une nouvelle commande
        /// </summary>
        /// <param name="query">Nom de la requette</param>
        /// <param name="isStoredProcedure">Prodécudre stockée ? true/flase</param>
        public Command(string query, bool isStoredProcedure = false)
        {
            Query = query;
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();
        }
        #endregion

        #region Méthodes
        
        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, value);
        }

        #endregion
    }
}
