﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using static Smooth.IoC.Dapper.Repository.UnitOfWork.Data.SessionExtensions;

namespace Smooth.IoC.Dapper.Repository.UnitOfWork.Data
{
    public static class UnitOfWorkExtensions
    {
        

        public static int BulkDelete<TEntity>(this IUnitOfWork uow,
            Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ? 
                uow.Connection.BulkDelete(statementOptions) : 
                uow.Connection.BulkDelete<TEntity>(statement=>statement.AttachToTransaction(uow.Transaction));
        }
        public static Task<int> BulkDeleteAsync<TEntity>(this IUnitOfWork uow,
            Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.BulkDeleteAsync(statementOptions) :
                uow.Connection.BulkDeleteAsync<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static int BulkUpdate<TEntity>(this IUnitOfWork uow, TEntity updateData,
            Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.BulkUpdate(updateData, statementOptions) :
                uow.Connection.BulkUpdate(updateData, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task<int> BulkUpdateAsync<TEntity>(this IUnitOfWork uow, TEntity updateData,
            Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.BulkUpdateAsync(updateData, statementOptions) :
                uow.Connection.BulkUpdateAsync(updateData, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static int Count<TEntity>(this IUnitOfWork uow,
            Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.Count(statementOptions) :
                uow.Connection.Count<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task<int> CountAsync<TEntity>(this IUnitOfWork uow,
            Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.CountAsync(statementOptions) :
                uow.Connection.CountAsync<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static bool Delete<TEntity>(this IUnitOfWork uow, TEntity entityToDelete,
            Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.Delete(entityToDelete,statementOptions) :
                uow.Connection.Delete(entityToDelete, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task<bool> DeleteAsync<TEntity>(this IUnitOfWork uow, TEntity entityToDelete,
            Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.DeleteAsync(entityToDelete,statementOptions) :
                uow.Connection.DeleteAsync(entityToDelete,statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static IEnumerable<TEntity> Find<TEntity>(this IUnitOfWork uow,
            Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.Find(statementOptions) :
                uow.Connection.Find<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task<IEnumerable<TEntity>> FindAsync<TEntity>(this IUnitOfWork uow,
            Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.FindAsync(statementOptions) :
                uow.Connection.FindAsync<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static TEntity Get<TEntity>(this IUnitOfWork uow, TEntity entityKeys,
            Action<ISelectSqlSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.Get(entityKeys,statementOptions) :
                uow.Connection.Get(entityKeys,statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task<TEntity> GetAsync<TEntity>(this IUnitOfWork uow, TEntity entityKeys,
            Action<ISelectSqlSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.GetAsync(entityKeys, statementOptions) :
                uow.Connection.GetAsync<TEntity>(entityKeys, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static void Insert<TEntity>(this IUnitOfWork uow, TEntity entityToInsert,
            Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            if (statementOptions != null)
            {
                uow.Connection.Insert(entityToInsert, statementOptions);
                return;
            }
            uow.Connection.Insert(entityToInsert, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task InsertAsync<TEntity>(this IUnitOfWork uow, TEntity entityToInsert,
            Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ? 
                uow.Connection.InsertAsync(entityToInsert, statementOptions) : 
                uow.Connection.InsertAsync(entityToInsert, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static bool Update<TEntity>(this IUnitOfWork uow, TEntity entityToUpdate,
            Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.Update(entityToUpdate, statementOptions) :
                uow.Connection.Update(entityToUpdate, statement => statement.AttachToTransaction(uow.Transaction));
        }

        public static Task<bool> UpdateAsync<TEntity>(this IUnitOfWork uow, TEntity entityToUpdate,
            Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
        {
            SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
            return statementOptions != null ?
                uow.Connection.UpdateAsync(entityToUpdate, statementOptions) :
                uow.Connection.UpdateAsync(entityToUpdate, statement => statement.AttachToTransaction(uow.Transaction));
        }

        private static void SetDialogueIfNeeded<TEntity>(SqlDialect sqlDialect)
        {
            var mapping = OrmConfiguration.GetDefaultEntityMapping<TEntity>();
            if (mapping.IsFrozen||mapping.Dialect == sqlDialect) return;
            lock (LockSqlDialectUpdate)
            {
                mapping = OrmConfiguration.GetDefaultEntityMapping<TEntity>(); //reload to be sure
                if (mapping.IsFrozen || mapping.Dialect == sqlDialect) return;
                mapping.SetDialect(sqlDialect);
            }
        }

    }

    
}