using ExtendedNationBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Managers
{
    public static class NationRemover
    {
        private static void DeleteFlag(string id)
        {
            string flagPath = Directories.Flags + id;
            File.Delete(flagPath + ".png");
            File.Delete(flagPath + ".jpg");
            File.Delete(flagPath + ".jpeg");
        }

        public static void Remove(this Nation nation) 
        {
            File.Delete(Directories.Flags + nation.Id + ".xml");
            DeleteFlag(nation.Flag.Id);
            DeleteFlag(nation.Flag.RevId);

            File.Delete(Directories.CustomNations + nation.Id + ".xml");
            File.Delete(Directories.Strings + nation.Id + ".xml");
            File.Delete(Directories.Names + nation.Id + ".xml");
        }
    }
}
