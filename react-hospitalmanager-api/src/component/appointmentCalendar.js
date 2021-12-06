import React, { useState } from 'react'
import DatePicker, {setHours, setMinutes, subDays, addDaysб, range, getYear, getMonth} from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'

export default function Calendar() {
    const [startDate, setStartDate] = useState(new Date());
    return (
      <DatePicker
      selected={startDate}
      onChange={(date) => setStartDate(date)}
      locale="ru"
      showTimeSelect
      timeFormat="p"
      timeIntervals={60}
      dateFormat="Pp"

      />
    );
}