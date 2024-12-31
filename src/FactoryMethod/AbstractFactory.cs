using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Factory抽象クラス
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// Create関数
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public AbstractProduct Create(string owner)
        {
            AbstractProduct product = CreateProduct(owner);
            RegisterProduct(product);
            return product;
        }

        /// <summary>
        /// 生成クラス
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        protected abstract AbstractProduct CreateProduct(string owner);
        
        /// <summary>
        /// 登録クラス
        /// </summary>
        /// <param name="product"></param>
        protected abstract void RegisterProduct(AbstractProduct product);
    }
}
