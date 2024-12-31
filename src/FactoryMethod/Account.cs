using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// アカウント情報クラス（Product具象クラス）
    /// </summary>
    public class Account : AbstractProduct
    {
        /// <summary>
        /// フィールド
        /// </summary>
        private readonly string? _owner;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="owner"></param>
        public Account(string owner)
        {
            this._owner = owner;
            Console.WriteLine("Create account: " + _owner);
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        public override void Use()
        {
            Console.WriteLine("Use account: " + _owner);
        }

        /// <summary>
        /// アカウント情報取得
        /// </summary>
        /// <returns></returns>
        public string GetOwner()
        {
            return _owner;
        }
    }
}
