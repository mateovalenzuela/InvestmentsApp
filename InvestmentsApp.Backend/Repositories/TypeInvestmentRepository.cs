using InvestmentsApp.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InvestmentsApp.Backend.Repositories
{
    public class TypeInvestmentRepository : ITypeInvestmentRepository
    {
        private readonly InvestmentsAppContext _context;

        public TypeInvestmentRepository(InvestmentsAppContext context)
        {
            _context = context;
        }

        public async Task Add(TypeInvestment entity)
            => await _context.TypeInvestments.AddAsync(entity);

        public void BajaLogica(TypeInvestment entity)
        {
            entity.Baja = true;
            _context.TypeInvestments.Attach(entity);
            _context.Entry(entity).Property(e => e.Baja).IsModified = true;
        }

        public async Task<TypeInvestment> GetActive(long id)
        {
            var typeInvestment = await _context.TypeInvestments.FindAsync(id);

            if (typeInvestment == null)
                return null;

            if (typeInvestment.Baja == false)
            {
                return typeInvestment;
            }

            return null;
        }

        public async Task<IEnumerable<TypeInvestment>> GetAllActives()
            => await _context.TypeInvestments
            .Where(t => t.Baja == false)
            .OrderBy(i => i.Id)
            .ToListAsync();

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<TypeInvestment> Search(Func<TypeInvestment, bool> filter, int limit)
             =>  _context.TypeInvestments.Where(filter)
                .Take(limit)
                .OrderBy(i => i.Id)
                .ToList();
        

        public void Update(TypeInvestment entity)
        {
            _context.TypeInvestments.Attach(entity);
            _context.Entry(entity).Property(e => e.Baja).IsModified = true;
        }
    }
}
