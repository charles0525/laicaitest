using FYL.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYL.Framework.DataProvider
{
    public class TestDbProvider : BaseDataProvider
    {
        public static readonly TestDbProvider instance = new TestDbProvider();

        public TestDbProvider(EnumDataProviderType emProvider = EnumDataProviderType.TestDb) : base(emProvider)
        {

        }
    }
}
