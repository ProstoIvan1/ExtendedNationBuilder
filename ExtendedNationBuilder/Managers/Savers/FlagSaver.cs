using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.XmlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Managers.Savers
{
    public class FlagSaver : Saver<Flag>
    {
        public string FlagPath { get; set; }
        public string SplinterFlagPath { get; set; }
        public FlagSaver(string nationId, string flagPath, string splinterFlagPath) : base(nationId) 
        { 
            FlagPath = flagPath;
            SplinterFlagPath = splinterFlagPath;
        }

        private void CopyFlag(string flagPath, string flagId)
        {
            FileInfo sourceFile = new(flagPath);
            FileInfo destFile = new FileInfo(Directories.Flags + flagId + sourceFile.Extension);

            if (sourceFile.FullName != destFile.FullName)
                File.Copy(sourceFile.FullName, destFile.FullName, true);
        }

        public override void Save(Flag flag)
        {
            Directory.CreateDirectory(Directories.Flags);

            CopyFlag(FlagPath, flag.Id);
            CopyFlag(SplinterFlagPath, flag.RevId);

            ACustomFlagWrapper wrapper = new()
            {
                FlagNames = [flag.Id, flag.RevId]
            };

            SaveEntity(wrapper, Directories.Flags);
        }
    }
}
