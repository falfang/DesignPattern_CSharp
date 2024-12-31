using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// アカウント生成クラス
    /// </summary>
    public class AccountFactory : AbstractFactory
    {
        private List<string> _owners;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountFactory()
        {
            _owners = new List<string>();
        }

        protected override AbstractProduct CreateProduct(string owner)
        {
            return new Account(owner);
        }

        protected override void RegisterProduct(AbstractProduct product)
        {
            _owners.Add( ((Account)product).GetOwner() );
        }


        public List<string> GetOwners()
        {
            return _owners;
        }
    }
}
