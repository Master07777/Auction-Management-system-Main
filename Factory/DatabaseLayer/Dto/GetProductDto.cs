using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.DatabaseLayer.Dto
{
    public class GetProductDto
    {
        public long ProductId { get; set; }

        public string Name { get; set; } = null!;

        public long? CategoryId { get; set; }

        public long? SellerId { get; set; }

        public string? BasePrice { get; set; }

        public string? ExpectedPrice { get; set; }
    }
}
