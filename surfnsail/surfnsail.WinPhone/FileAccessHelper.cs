﻿using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;

namespace surfnsail.WinPhone
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string dbPath = Path.Combine(path, filename);

            CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }

        public static void CopyDatabaseIfNotExists(string dbPath)
        {
            var storageFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!storageFile.FileExists(dbPath))
            {
                using (var resourceStream = Application.GetResourceStream(new Uri("surfnsailSQLite.db3", UriKind.Relative)).Stream)
                {
                    using (var fileStream = storageFile.CreateFile(dbPath))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytes = -1;

                        while ((bytes = resourceStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            fileStream.Write(readBuffer, 0, bytes);
                        }
                    }
                }
            }
        }
    }

}
