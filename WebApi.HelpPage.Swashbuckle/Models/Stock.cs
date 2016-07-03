namespace WebApi.HelpPage.Swashbuckle.Models
{
    /// <summary>
    /// 股票信息
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// 股票代码
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 股票名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 交易所
        /// </summary>
        public string Exchange { get; set; }
    }
}