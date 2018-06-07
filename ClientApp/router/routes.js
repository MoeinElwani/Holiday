import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import Item from 'components/Items/item'
import mmm from 'components/mmm'
import payment from 'components/Payments/payment'
import Groups from 'components/Groups/groups'
import POS from 'components/POS/Pos'
export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'الرئيسية', icon: 'home' },
  //{ name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
 // { name: 'fetch-data', path: '/fetch-data', component: FetchData, display: 'Fetch data', icon: 'list' },
  { name: 'payment', path: '/payment', component: payment, display: 'طرق الدفع', icon: 'graduation-cap' },
  { name: 'groups' , path: '/groups ', component: Groups,  display: 'المجموعات',  icon: 'list' },
  { name: 'POS'    , path: '/POS'    , component: POS,     display: 'نقطة البيع',     icon: 'home' },
  { name: 'item'   , path: '/item'   , component: Item,    display: 'الأصناف',    icon: 'list' }]
