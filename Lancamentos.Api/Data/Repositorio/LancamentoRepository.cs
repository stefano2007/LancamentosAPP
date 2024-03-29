﻿using Lancamentos.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Data.Repositorio
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly LancamentoContext _context;
        public LancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }
        public async Task Atualizar(int usuarioId, Lancamento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Lancamento> BuscarPorId(int usuarioId, int id)
        {
            return await _context
                    .Lancamentos
                    .Where(x => x.UsuarioId == usuarioId)
                    .Include(l => l.Usuario)
                    .Include(l => l.TipoLancamento)
                    .Include(l => l.Conta)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Lancamento>> BuscatTodos(int usuarioId, int limite = 25, int salto = 0)
        {
            return await _context
                    .Lancamentos
                    .Where(x => x.UsuarioId == usuarioId)
                    .Include(l => l.Usuario)
                    .Include(l => l.TipoLancamento)
                    .Include(l => l.Conta)
                    .AsNoTracking()
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<Lancamento> Criar(Lancamento entity)
        {
            _context.Lancamentos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Deletar(int usuarioId, Lancamento entity)
        {
            _context.Lancamentos.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Exists(int id)
        {
            return await _context
                    .Lancamentos
                    .AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Lancamento>> GetLancamentosPorMesAno(int usuarioId, int mes, int ano)
        {
            return await _context
                    .Lancamentos
                    .Where(p => 
                        p.UsuarioId == usuarioId
                     && p.Data.Month == mes
                     && p.Data.Year == ano)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Lancamento>> GetLancamentosPorAno(int usuarioId, int ano)
        {
            return await _context
                    .Lancamentos
                    .Where(p =>
                        p.UsuarioId == usuarioId
                     && p.Data.Year == ano)
                    .ToListAsync();
        }
    }
}
