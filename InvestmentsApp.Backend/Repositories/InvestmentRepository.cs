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

        public async Task Add(Investmetn entity)
            => await _context.Investmetns.AddAsync(entity);

        public void BajaLogica(Investmetn entity)
        {
            entity.Baja = true;
            _context.Investmetns.Attach(entity);
            _context.Entry(entity).Property(e => e.Baja).IsModified = true;
        }

        public async Task<Investmetn> GetActive(long id)
        {
            var investment = await _context.Investmetns.FindAsync(id);

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

        public async Task<IEnumerable<Investmetn>> GetActiveByTicker(string ticker)
        {
            var investments = await _context.Investmetns
                .Where(i => i.Tikcker == ticker && i.Baja == false)
                .Include(i => i.TypeInvestment)
                .OrderByDescending(i => i.Id)
                .ToListAsync();

            if (investments.Count != 0)
            {
                return investments;
            }

            return null;
        }

        public async Task<IEnumerable<Investmetn>> GetActiveByTypeInvestment(long idTypeInvestment)
        {
            var investments = await _context.Investmetns
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

        public async Task<IEnumerable<Investmetn>> GetAllActives()
            => await _context.Investmetns
            .Where(i => i.Baja == false)
            .Include(i => i.TypeInvestment)
            .OrderByDescending(i => i.Id)
            .ToListAsync();

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Investmetn> Search(Func<Investmetn, bool> filter, int limit)
            => _context.Investmetns.Where(filter)
            .Take(limit)
            .OrderByDescending(i => i.Id)
            .ToList();

        public void Update(Investmetn entity)
        {
            _context.Investmetns.Attach(entity);
            _context.Entry(entity).Property(e => e.Baja).IsModified = true;
        }
    }
}
