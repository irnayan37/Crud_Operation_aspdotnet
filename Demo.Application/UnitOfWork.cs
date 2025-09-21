using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Demo.Application
{
    public class UnitOfWork
    {
        public ProductRepository ProductRepository { get; set; }
        public UserRepository UserRepository { get; set; }

        public void Commit()
        {

        }
    }
}
