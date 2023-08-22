using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Models.ViewModels;

namespace UserAPI.Repository
{
    public class RecordsRepository : IRecordsRepository
    {
        private UserDbContext _context;
        public RecordsRepository(UserDbContext context)
        {
            _context = context;
        }

        public ViewModelRecord Add(ViewModelRecord record)
        {
            Record modelRecord = mapViewModelToModel(record);
            var filteredRecord = _context.Records.Where(r => r.Date == modelRecord.Date && r.UserId == modelRecord.UserId);
            if (filteredRecord.Count() > 0) {
                //throw Exception("record already exits");
                throw new Exception("Record already exits");
            }
            _context.Records.Add(modelRecord);
            _context.SaveChanges();

            foreach (RecordWiseMeal rwm in record.RecordWiseMeals) 
            {
               rwm.RecordId = _context.Records.Where(r => (r.Date == record.Date) && (r.UserId == record.UserId)).LastOrDefault().Id;

                rwm.Id = 0;
                _context.RecordWiseMeals.Add(rwm);    
            }

            foreach (RecordWiseWorkout rww in record.RecordWiseWorkouts)
            {
                rww.RecordId = _context.Records.Where(r => r.Date == record.Date).FirstOrDefault().Id;
                rww.Id = 0;
                _context.RecordWiseWorkouts.Add(rww);
            }
            _context.SaveChanges();
            ViewModelRecord viewRecord = mapModelToViewModel(_context.Records.FirstOrDefault(r => r.Date == record.Date));
            return viewRecord;
        }

        public void Delete(int recordId)
        {
            Record r = _context.Records.FirstOrDefault(r => r.Id == recordId);

            if (r != null) {
                // delete record wise meals and workouts
                IEnumerable<RecordWiseMeal> rm_list = _context.RecordWiseMeals.Where(rm => rm.RecordId == r.Id);
                IEnumerable<RecordWiseWorkout> rw_list = _context.RecordWiseWorkouts.Where(rm => rm.RecordId == r.Id);
                foreach (RecordWiseMeal forrec in rm_list)
                {
                    _context.RecordWiseMeals.Remove(forrec);
                }

                foreach (RecordWiseWorkout forrec in rw_list)
                {
                    _context.RecordWiseWorkouts.Remove(forrec);
                }
                _context.Records.Remove(r);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public void DeleteAll(int UserId)
        {
            List<Record> list = GetByUserId(UserId);
            foreach (Record record in list) 
            {
                _context.Records.Remove(record);
            }
        }

        public ViewModelRecord Update(ViewModelRecord record)
        {
           Record r =  _context.Records.FirstOrDefault(r => r.Id == record.Id);
            r.Weight = record.Weight;

           var rwmFiltered = _context.RecordWiseMeals.Where(rwm => rwm.RecordId == record.Id);
           var rwwFiltered = _context.RecordWiseWorkouts.Where(rww => rww.RecordId == record.Id);

            foreach (RecordWiseMeal rwm in rwmFiltered)
            {
                var incomingRecord = record.RecordWiseMeals.Where(irwm => irwm.Id == rwm.Id).FirstOrDefault();
                if(incomingRecord != null)
                {
                    rwm.MealId = incomingRecord.MealId;
                    rwm.MealQuantity = incomingRecord.MealQuantity;
                }
            }

          

            foreach (RecordWiseWorkout rww in rwwFiltered)
            {
                var incomingRecord = record.RecordWiseWorkouts.Where(irwm => irwm.Id == rww.Id).FirstOrDefault();
                rww.WorkoutId = incomingRecord.WorkoutId;
                rww.Reps = incomingRecord.Reps;
            }

            foreach (RecordWiseMeal rwm in record.RecordWiseMeals)
            {
                if (rwm.Id == 0)
                {
                    _context.RecordWiseMeals.Add(rwm);
                }
            }

            foreach (RecordWiseWorkout rww in record.RecordWiseWorkouts)
            {
                if (rww.Id == 0)
                {
                    _context.RecordWiseWorkouts.Add(rww);
                }
            }

            _context.SaveChanges();
            return record;
        }

        public List<Record> GetByUserId(int UserId)
        {
            List<Record> r = _context.Records.ToList();
            List<Record> filteredList = r.Where(re => re.UserId == UserId).ToList();

           /* List <ViewModelRecord> viewModelList= new List<ViewModelRecord>();
            foreach (Record rec in filteredList) 
            {

                viewModelList.Add( mapModelToViewModel(rec));
            }*/
            return filteredList;
        }

        public ViewModelRecord mapModelToViewModel(Record record)
        {
            ViewModelRecord viewRecord = new ViewModelRecord();
            viewRecord.Date = record.Date;
            viewRecord.UserId = record.UserId;
            viewRecord.Date = record.Date;
            viewRecord.Weight = record.Weight;
            viewRecord.Id = record.Id;

            viewRecord.RecordWiseMeals = _context.RecordWiseMeals.Where(rwm => rwm.RecordId == record.Id).ToList();
            viewRecord.RecordWiseWorkouts = _context.RecordWiseWorkouts.Where(rwm => rwm.RecordId == record.Id).ToList();

            return viewRecord;
        }

        public Record mapViewModelToModel(ViewModelRecord record)
        {
            Record viewRecord = new Record();
            viewRecord.Date = record.Date;
            viewRecord.UserId = record.UserId;
            viewRecord.Date = record.Date;
            viewRecord.Weight = record.Weight;

            // viewRecord.RecordWiseMeals
            // viewRecord.RecordWiseWorkouts

            return viewRecord;
        }
    }
}
