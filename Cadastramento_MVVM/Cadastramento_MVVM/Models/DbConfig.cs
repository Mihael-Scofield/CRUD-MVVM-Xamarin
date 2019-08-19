using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cadastramento_MVVM.Models {
    public class DbConfig {
        public string GetDbPath() {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "clientDB.db");
            return dbPath;
        }
    }
}