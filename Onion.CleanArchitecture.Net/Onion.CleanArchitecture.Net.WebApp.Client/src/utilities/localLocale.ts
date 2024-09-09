import moment from 'moment';
import 'moment/dist/locale/vi';

const localLocale = () => {
  moment.locale('vi');
  moment.updateLocale('vi', {
    invalidDate: 'Ngày không hợp lệ',
  });
  return moment;
};

export {localLocale};
