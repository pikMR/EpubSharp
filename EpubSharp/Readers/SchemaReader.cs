﻿using System.IO.Compression;
using EpubSharp.Entities;
using EpubSharp.Schema.Navigation;
using EpubSharp.Schema.Opf;
using EpubSharp.Utils;

namespace EpubSharp.Readers
{
    internal static class SchemaReader
    {
        public static EpubSchema ReadSchema(ZipArchive epubArchive)
        {
            EpubSchema result = new EpubSchema();
            string rootFilePath = RootFilePathReader.GetRootFilePath(epubArchive);
            string contentDirectoryPath = ZipPathUtils.GetDirectoryPath(rootFilePath);
            result.ContentDirectoryPath = contentDirectoryPath;
            EpubPackage package = PackageReader.ReadPackage(epubArchive, rootFilePath);
            result.Package = package;
            EpubNavigation navigation = NavigationReader.ReadNavigation(epubArchive, contentDirectoryPath, package);
            result.Navigation = navigation;
            return result;
        }
    }
}
