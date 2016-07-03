using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.HelpPage.Microsoft.Models;

namespace WebApi.HelpPage.Microsoft.Controllers
{
    /// <summary>
    /// 股票数据接口
    /// </summary>
    [RoutePrefix("api/stocks")]
    public class StocksController : ApiController
    {
        private readonly List<Stock> _stocks;

        /// <summary>
        /// 构造函数
        /// </summary>
        public StocksController()
        {
            _stocks = new List<Stock>
            {
                new Stock{Symbol = "000001", Name = "平安银行", Exchange = "深证交易所"},
                new Stock{Symbol = "000002", Name = "万科A", Exchange = "深证交易所"},
                new Stock{Symbol = "000003", Name = "PT金田A", Exchange = "深证交易所"},
                new Stock{Symbol = "000004", Name = "国农科技", Exchange = "深证交易所"},
                new Stock{Symbol = "000005", Name = "世纪星源", Exchange = "深证交易所"}
            };
        }

        /// <summary>
        /// 获取股票列表
        /// </summary>
        /// <returns>股票列表</returns>
        [HttpGet]
        public IEnumerable<Stock> List()
        {
            return _stocks;
        }

        /// <summary>
        /// 获取指定股票
        /// </summary>
        /// <param name="symbol">股票代码</param>
        /// <returns>指定股票</returns>
        [HttpGet(), Route("{symbol}", Name = "Get")]
        public IHttpActionResult Get(string symbol)
        {
            var stock = _stocks.SingleOrDefault(n => n.Symbol == symbol);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        /// <summary>
        /// 添加一支股票
        /// </summary>
        /// <param name="stock">股票信息</param>
        [HttpPost]
        public IHttpActionResult Create(Stock stock)
        {
            return CreatedAtRoute("Get", new { symbol = stock.Symbol }, stock);
        }

        /// <summary>
        /// 更新一支股票
        /// </summary>
        /// <param name="stock">股票信息</param>
        [HttpPut]
        public IHttpActionResult Update(Stock stock)
        {
            if (_stocks.All(n => n.Symbol != stock.Symbol))
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 部分更新一支股票
        /// </summary>
        /// <param name="symbol">股票代码</param>
        /// <param name="form">需要更新的股票信息</param>
        [HttpPatch, Route("{symbol}")]
        public IHttpActionResult PartialUpdate(string symbol, PartialForm form)
        {
            if (_stocks.All(n => n.Symbol != symbol))
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 删除一支股票
        /// </summary>
        /// <param name="symbol">股票代码</param>
        /// <returns>是否删除成功</returns>
        [HttpDelete, Route("{symbol}")]
        public IHttpActionResult Delete(string symbol)
        {
            if (_stocks.All(n => n.Symbol != symbol))
            {
                return NotFound();
            }

            return Ok(true);
        }

        /// <summary>
        /// 这个方法不会显示到帮助页面
        /// </summary>
        [HttpGet, Route("hide")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void NotShow()
        {

        }
    }
}
