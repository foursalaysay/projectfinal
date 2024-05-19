using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projectfinal
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Data>().Wait();
        }

        //Insert or Update record
        public async Task<Data> SaveItemAsync(Data electricity)
        {
            if (electricity.empNo != 0)
            {
                await db.UpdateAsync(electricity);
            }
            else
            {
                await db.InsertAsync(electricity);
            }

            // Retrieve the saved Data object with empNo populated
            Data savedData = await db.Table<Data>().Where(d => d.empNo == electricity.empNo).FirstOrDefaultAsync();

            return savedData;
        }

        public async Task<Data> UpdateItemAsync(Data updatedData, int empNo)
        {
            // Retrieve the existing record based on empNo
            Data existingData = await ReadItemAsync(empNo);

            if (existingData != null)
            {
                // Update the existing record with the new data
                existingData.empName = updatedData.empName;
                existingData.hoursWork = updatedData.hoursWork;
                existingData.empStatus = updatedData.empStatus;
                existingData.civilStatus = updatedData.civilStatus;
                existingData.ratePerHour = updatedData.ratePerHour;
                existingData.basicIncome = updatedData.basicIncome;
                existingData.overtimeIncome = updatedData.overtimeIncome;
                existingData.grossIncome = updatedData.grossIncome;
                existingData.SSS = updatedData.SSS;
                existingData.WTAX = updatedData.WTAX;
                existingData.PHILHEALTH = updatedData.PHILHEALTH;
                existingData.PAGIBIG = updatedData.PAGIBIG;
                existingData.DEDUCTION = updatedData.DEDUCTION;
                existingData.netIncome = updatedData.netIncome;

                // Update the record in the database
                await db.UpdateAsync(existingData);

                return existingData; // Return the updated record
            }
            else
            {
                // Handle the case when the record is not found
                return null;
            }
        }




        //Delete Record
        public Task<int> DeleteItemAsync(int empNo)
        {
            return db.DeleteAsync<Data>(empNo);
        }

        //Read all Item
        public Task<List<Data>> ReadAllItemAsync()
        {
            return db.Table<Data>().ToListAsync();
        }

        //Read Item
        public Task<Data> ReadItemAsync(int meterNo)
        {
            return db.Table<Data>().Where(i => i.empNo == meterNo).FirstOrDefaultAsync();
        }

        // GETTING THE LATEST DATA
        public async Task<Data> ReadLatestItemAsync()
        {
            var data = await db.Table<Data>()
                .OrderByDescending(i => i.empNo)
                .FirstOrDefaultAsync();

            return data;
        }
    }
}
