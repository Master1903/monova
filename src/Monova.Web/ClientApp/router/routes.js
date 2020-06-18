// import HomePage from '@/components/pages/home-page'
import MonitoringList from '@/components/pages/monitoring/list'
import MonitoringSave from '@/components/pages/monitoring/save'
import Forbidden from '@/components/shared/forbidden'

export const routes = [

  {
    name: 'monitoring-list',
    path: '/monitoring/list',
    component: MonitoringList,
    display: 'Monitoring',
    icon: 'chart-line'
  },
  {
    name: 'monitoring-save',
    path: '/monitoring/save',
    component: MonitoringSave,
    display: 'New Monitoring',
    icon: 'plus'
  },
  {
    name: 'forbidden',
    path: '/forbidden',
    display: 'Forbidden',
    component: Forbidden,
    hidden: true,
    icon: 'plus'
  },
  // identity sayfaları
  {
    name: 'account-view',
    path: '/Identity/Account/Manage',
    display: 'Account',
    icon: 'user-circle'
  },
  {
    name: 'account-subscription',
    path: '/subscription',
    display: 'Subscription',
    icon: 'credit-card'
  }
  // </ identity sayfaları
]
