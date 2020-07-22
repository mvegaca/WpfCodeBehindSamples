using System;
using System.Collections;
using System.IO;
using CodeBehindApp.Core.Services;

namespace CodeBehindApp.Services
{
    public class PersistAndRestoreService
    {
        private const string ConfigurationsFolder = "CodeBehindApp\\Configurations";
        private const string AppPropertiesFileName = "AppProperties.json";

        private readonly FileService _fileService;
        private readonly string _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public PersistAndRestoreService()
        {
            _fileService = new FileService();
        }

        public void PersistData()
        {
            if (App.Current.Properties != null)
            {
                var folderPath = Path.Combine(_localAppData, ConfigurationsFolder);
                _fileService.Save(folderPath, AppPropertiesFileName, App.Current.Properties);
            }
        }

        public void RestoreData()
        {
            var folderPath = Path.Combine(_localAppData, ConfigurationsFolder);
            var properties = _fileService.Read<IDictionary>(folderPath, AppPropertiesFileName);
            if (properties != null)
            {
                foreach (DictionaryEntry property in properties)
                {
                    App.Current.Properties.Add(property.Key, property.Value);
                }
            }
        }
    }
}
