using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class BaseRoom : MonoBehaviour
    {
        public WebForm webManager;

        private void Start()
        {
            webManager = WebForm.WebManager;
        }

        public void SendFormData(string formAddress)
        {

        }

        #region Button Functions
        /// <summary>
        /// Add a field to the current form.
        /// </summary>
        /// <param name="field">Name of the field, and the value. (use comma ',' to split the field name and the value).
        ///                         The field name should always come first, and value after; for example "entry.000,value".</param>
        public void AddToForm(string field)
        {
            string[] splitParams = field.Split(',');

            webManager.AddField(splitParams[0], splitParams[1]);
        }
        #endregion 
    }
}
