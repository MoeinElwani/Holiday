import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/Home/home'
import Item from 'components/Items/item'
import mmm from 'components/mmm'
import payment from 'components/Payments/payment'
import Groups from 'components/Groups/groups'
import POS from 'components/POS/Pos'
import ReverseInvoice from 'components/ReverseInvoice/reverseInvoice'

export const routes = [
  { Primet: true, name: 'home', path: '/', component: HomePage, display: 'الرئيسية', icon: 'home' },
  { Primet: true, name: 'payment', path: '/payment', component: payment, display: 'طرق الدفع', icon: 'money-bill' },
  { Primet: true, name: 'groups', path: '/groups ', component: Groups, display: 'المجموعات', icon: 'object-ungroup' },
  { Primet: true, name: 'POS', path: '/POS', component: POS, display: 'نقطة البيع', icon: 'cart-plus' },
  { Primet: true, name: 'ReverseInvoice', path: '/ReverseInvoice', component: ReverseInvoice, display: ' ترجيع ', icon: 'recycle' },
  { Primet: true, name: 'item', path: '/item', component: Item, display: 'الأصناف', icon: 'image' }]
