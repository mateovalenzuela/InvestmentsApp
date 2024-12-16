using InvestmentsApp.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentsApp.Backend.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly InvestmentsAppContext _context;

        public InvestmentRepository(InvestmentsAppContext context)
        {
            _context = context;
        }

        public async Task Add(Investment entity)
            => await _context.Investments.AddAsync(entity);

        public void BajaLogica(Investment entity)
        {
            entity.Baja = true;
            _context.Investments.Attach(entity);
            _context.Entry(entity).Property(e => e.Baja).IsModified = true;
        }

        public async Task<Investment> GetActive(long id)
        {
            var investment = await _context.Investments.FindAsync(id);

            if (investment == null)
            {
                return null;
            }

            if (investment.Baja == false) 
            {
                return investment;
            }

            return null;
        }

        public async Task<IEnumerable<Investment>> GetActiveByTicker(string ticker)
        {
            var investments = await _context.Investments
                .Where(i => i.Ticker == ticker && i.Baja == false)
                .Include(i => i.TypeInvestment)
                .OrderByDescending(i => i.Id)
                .ToListAsync();

            if (investments.Count != 0)
            {
                return investments;
            }

            return null;
        }

        public async Task<IEnumerable<Investment>> GetActiveByTypeInvestment(long idTypeInvestment)
        {
            var investments = await _context.Investments
                .Where(i => i.IdTypeInvestment == idTypeInvestment &&i.Baja == false)
                .Include(i => i.TypeInvestment)
                .OrderByDescending(i => i.Id)
                .ToListAsync();

            if (investments.Count != 0)
            {
                return investments;
            }

            return null;
        }

        public async Task<IEnumerable<Investment>> GetAllActives()
            => await _context.Investments
            .Where(i => i.Baja == false)
            .Include(i => i.TypeInvestment)
            .OrderByDescending(i => i.Id)
            .ToListAsync();

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Investment> Search(Func<Investment, bool> filter, int limit)
            => _context.Investments.Where(filter)
            .Take(limit)
            .OrderByDescending(i => i.Id)
            .ToList();

        public void Update(Investment entity)
        {
            _context.Investments.Attach(entity);
            _context.Entry(entity).Property(e => e.Baja).IsModified = true;
        }
    }
}
