using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Product抽象クラス
    /// </summary>
    public abstract class AbstractProduct
    {
        /// <summary>
        /// 誰のアカウントを使っているか
        /// </summary>
        public abstract void Use();
    }
}
