using CalculEcolage.Database;
using CalculEcolage.Models;
using SQLite;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CalculEcolage
{
    public class TuitionFeesDatabase 
    {
        readonly SQLiteAsyncConnection _database;

        static InitializeDatabase ini ;
        public TuitionFeesDatabase(string dbPath)

        {
            ini = new InitializeDatabase();

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<EnrolementFees>().Wait();
            _database.CreateTableAsync<TuitionFees>().Wait();
            _database.CreateTableAsync<FixedCharges>().Wait();
            _database.CreateTableAsync<ExternalExaminationFees>().Wait();
            _database.CreateTableAsync<SchoolMeals>().Wait();
            _database.CreateTableAsync<WednesdayMeals>().Wait();
            _database.CreateTableAsync<SchoolTransport>().Wait();
            _database.CreateTableAsync<Supervision>().Wait();
            _database.CreateTableAsync<Support>().Wait();
            _database.CreateTableAsync<AssistanceDiscount>().Wait();
            _database.CreateTableAsync<TermDiscount>().Wait();
            _database.CreateTableAsync<Child>().Wait();
            _database.CreateTableAsync<Family>().Wait();

            
        }
        //TuitionFees Queries
        public Task<List<TuitionFees>> GetTuittionFeesListAsync()
        {
            return _database.Table<TuitionFees>().ToListAsync();
        }

        public Task<TuitionFees> GetTuitionFeesAsync(string id)
        {
            return _database.Table<TuitionFees>()
                            .Where(i => i.yearName == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveTuitionFeesAsync(TuitionFees tuitionFees)
        {
            var checkIfexists = new TuitionFees();
            checkIfexists = await GetTuitionFeesAsync(tuitionFees.yearName);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(tuitionFees);
            }
            else return await _database.InsertAsync(tuitionFees);
        }

        public Task<int> DeleteTuitionFeesAsync(TuitionFees tuitionFees)
        {
            return _database.DeleteAsync(tuitionFees);
        }
        //----------------------------------------EnrolementFees Queries---------------------------------------
        public Task<List<EnrolementFees>> GetEnrolementFeesListAsync()
        {
            return _database.Table<EnrolementFees>().ToListAsync();
        }

        public Task<EnrolementFees> GetEnrolementFeesAsync(int id)
        {
            return _database.Table<EnrolementFees>()
                            .Where(i => i.id == id )
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveEnrolementFeesAsync(EnrolementFees enrolementFees)
        {
            var checkIfexists = new EnrolementFees();
            checkIfexists = await GetEnrolementFeesAsync(enrolementFees.id);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(enrolementFees);
            }
            else return await _database.InsertAsync(enrolementFees);
        }
        //-----------------------------------------------------FixedCharges Queries-------------------------------------
        public Task<List<FixedCharges>> GetFixedChargesListAsync()
        {
            return _database.Table<FixedCharges>().ToListAsync();
        }

        public Task<FixedCharges> GetFixedChargesAsync(string id)
        {
            return _database.Table<FixedCharges>()
                            .Where(i => i.yearName == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveFixedChargesAsync(FixedCharges fixedCharges)
        {
            var checkIfexists = new FixedCharges();
            checkIfexists = await GetFixedChargesAsync(fixedCharges.yearName);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(fixedCharges);
            }
            else return await _database.InsertAsync(fixedCharges);
        }

        public Task<int> DeleteFixedChargesAsync(FixedCharges fixedCharges)
        {
            return _database.DeleteAsync(fixedCharges);
        }
        //-----------------------------------------------------ExternalExaminationFees Queries-------------------------------------
        public Task<List<ExternalExaminationFees>> GetExternalExaminationFeesListAsync()
        {
            return _database.Table<ExternalExaminationFees>().ToListAsync();
        }

        public Task<ExternalExaminationFees> GetExternalExaminationFeesAsync(string id)
        {
            return _database.Table<ExternalExaminationFees>()
                            .Where(i => i.yearName == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveExternalExaminationFeesAsync(ExternalExaminationFees externalExaminationFees)
        {
            var checkIfexists = new ExternalExaminationFees();
            checkIfexists = await GetExternalExaminationFeesAsync(externalExaminationFees.yearName);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(externalExaminationFees);
            }
            else return await _database.InsertAsync(externalExaminationFees);
        }

        public Task<int> DeleteExternalExaminationFeesAsync(ExternalExaminationFees externalExaminationFees)
        {
            return _database.DeleteAsync(externalExaminationFees);
        }
        //-----------------------------------------------------SchoolMeals Queries-------------------------------------
        public Task<List<SchoolMeals>> GetSchoolMealsListAsync()
        {
            return _database.Table<SchoolMeals>().ToListAsync();
        }

        public Task<SchoolMeals> GetSchoolMealsAsync(string id)
        {
            return _database.Table<SchoolMeals>()
                            .Where(i => i.yearName == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveSchoolMealsAsync(SchoolMeals schoolMeals)
        {
            var checkIfexists = new SchoolMeals();
            checkIfexists = await GetSchoolMealsAsync(schoolMeals.yearName);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(schoolMeals);
            }
            else return await _database.InsertAsync(schoolMeals);
        }

        public Task<int> DeleteSchoolMealsAsync(SchoolMeals schoolMeals)
        {
            return _database.DeleteAsync(schoolMeals);
        }
        //-----------------------------------------------------WednesdayMeals Queries-------------------------------------
        public Task<List<WednesdayMeals>> GetWednesdayMealsListAsync()
        {
            return _database.Table<WednesdayMeals>().ToListAsync();
        }

        public Task<WednesdayMeals> GetWednesdayMealsAsync(string id)
        {
            return _database.Table<WednesdayMeals>()
                            .Where(i => i.yearName == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveWednesdayMealsAsync(WednesdayMeals wednesdayMeals)
        {
            var checkIfexists = new WednesdayMeals();
            checkIfexists = await GetWednesdayMealsAsync(wednesdayMeals.yearName);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(wednesdayMeals);
            }
            else return await _database.InsertAsync(wednesdayMeals);
        }

        public Task<int> DeleteWednesdayMealsAsync(WednesdayMeals wednesdayMeals)
        {
            return _database.DeleteAsync(wednesdayMeals);
        }
        //-----------------------------------------------------SchoolTransport Queries-------------------------------------//
        public Task<List<SchoolTransport>> GetSchoolTransportListAsync()
        {
            return _database.Table<SchoolTransport>().ToListAsync();
        }

        public Task<SchoolTransport> GetSchoolTransportAsync(string id)
        {
            return _database.Table<SchoolTransport>()
                            .Where(i => i.zone == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveSchoolTransportAsync(SchoolTransport schoolTransport)
        {
            var checkIfexists = new SchoolTransport();
            checkIfexists = await GetSchoolTransportAsync(schoolTransport.zone);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(schoolTransport);
            }
            else return await _database.InsertAsync(schoolTransport);
        }

        public Task<int> DeleteSchoolTransportAsync(SchoolTransport schoolTransport)
        {
            return _database.DeleteAsync(schoolTransport);
        }
        //-----------------------------------------------------Supervision Queries-------------------------------------
        public Task<List<Supervision>> GetSupervisionListAsync()
        {
            return _database.Table<Supervision>().ToListAsync();
        }

        public Task<Supervision> GetSupervisionAsync(string id)
        {
            return _database.Table<Supervision>()
                            .Where(i => i.name == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveSupervisionAsync(Supervision supervision)
        {
            var checkIfexists = new Supervision();
            checkIfexists = await GetSupervisionAsync(supervision.name);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(supervision);
            }
            else return await _database.InsertAsync(supervision);
        }

        public Task<int> DeleteSupervisionAsync(Supervision supervision)
        {
            return _database.DeleteAsync(supervision);
        }
        //-----------------------------------------------------Support Queries-------------------------------------
        public Task<List<Support>> GetSupportListAsync()
        {
            return _database.Table<Support>().ToListAsync();
        }

        public Task<Support> GetSupportAsync(string id)
        {
            return _database.Table<Support>()
                            .Where(i => i.name == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveSupportAsync(Support support)
        {
            var checkIfexists = new Support();
            checkIfexists = await GetSupportAsync(support.name);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(support);
            }
            else return await _database.InsertAsync(support);
        }

        public Task<int> DeleteSupportAsync(Support support)
        {
            return _database.DeleteAsync(support);
        }
        //-----------------------------------------------------AssistanceDiscount Queries-------------------------------------
        public Task<List<AssistanceDiscount>> GetAssistanceDiscountListAsync()
        {
            return _database.Table<AssistanceDiscount>().ToListAsync();
        }

        public Task<AssistanceDiscount> GetAssistanceDiscountAsync(string id)
        {
            return _database.Table<AssistanceDiscount>()
                            .Where(i => i.name == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveAssistanceDiscountAsync(AssistanceDiscount assistanceDiscount)
        {
            var checkIfexists = new AssistanceDiscount();
            checkIfexists = await GetAssistanceDiscountAsync(assistanceDiscount.name);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(assistanceDiscount);
            }
            else return await _database.InsertAsync(assistanceDiscount);
        }

        public Task<int> DeleteAssistanceDiscountAsync(AssistanceDiscount assistanceDiscount)
        {
            return _database.DeleteAsync(assistanceDiscount);
        }
        //-----------------------------------------------------TermDiscount Queries-------------------------------------
        public Task<List<TermDiscount>> GetTermDiscountListAsync()
        {
            return _database.Table<TermDiscount>().ToListAsync();
        }

        async public Task<TermDiscount> GetTermDiscountAsync(string id)
        {
            
            return await _database.Table<TermDiscount>()
                            .Where(i => i.name == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveTermDiscountAsync(TermDiscount termDiscount)
        {
            var checkIfexists = new TermDiscount();
            checkIfexists = await GetTermDiscountAsync(termDiscount.name);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(termDiscount);
            }
            else return await _database.InsertAsync(termDiscount);
        }

        public Task<int> DeleteTermDiscountAsync(TermDiscount termDiscount)
        {
            return _database.DeleteAsync(termDiscount);
        }
        //------------------------------------------Child Queries-------------------------------------------------------------//
        public Task<List<Child>> GetChildListAsync()
        {
            return _database.Table<Child>().ToListAsync();
        }

        public Task<List<Child>> GetChildListByFamilyAsync(int id)
        {
            return _database.Table<Child>().Where(i => i.familyId == id).ToListAsync();
        }
        public Task<Child> GetChildAsync(string id)
        {
            return _database.Table<Child>()
                            .Where(i => i.childName == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Child> GetChildByIdAsync(int id)
        {
            return _database.Table<Child>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveChildAsync(Child child)
        {
            var checkIfexists = new Child();
            checkIfexists = await GetChildByIdAsync(child.id);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(child);
            }
            else return await _database.InsertAsync(child);
        }

        public Task<int> DeleteChildAsync(Child child)
        {
            return _database.DeleteAsync(child);
        }
        //------------------------------------------Family Queries-------------------------------------------------------------//
        public Task<List<Family>> GetFamilyListAsync()
        {
            return _database.Table<Family>().ToListAsync();
        }

        public Task<Family> GetFamilyAsync(string id)
        {
            return _database.Table<Family>()
                            .Where(i => i.familyName == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Family> GetFamilyByIdAsync(int id)
        {
            return _database.Table<Family>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }

        async public Task<int> SaveFamilyAsync(Family family)
        {
            var checkIfexists = new Family();
            checkIfexists = await GetFamilyByIdAsync(family.id);


            if (checkIfexists != null)
            {
                return await _database.UpdateAsync(family);
            }
            else return await _database.InsertAsync(family);
        }

        public Task<int> DeleteFamilyAsync(Family tuitionFees)
        {
            return _database.DeleteAsync(tuitionFees);
        }

        //------------------------------------------drop tables-------------------------------------------------------------//
        public void DropFamilyTable()
        {
           _database.DropTableAsync<Family>();
        }
        public void DropChildTable()
        {
           _database.DropTableAsync<Child>();
        }
    }
}
