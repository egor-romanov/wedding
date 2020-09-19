import Home from './components/Home';
import Contact from './components/Contact';
import Info from './components/Info';
import Guests from './components/Guests';
import Guest from './components/Guest';
import Invitation from './components/Invitation';
import GiftList from './components/GiftList';
import Songs from './components/Songs';
import Photos from './components/Photos';
import Auth from './components/Auth';

module.exports = {
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', name: 'home', component: Home },
    { path: '/contact', name: 'contact', component: Contact },
    { path: '/info', name: 'info', component: Info },
    { path: '/guests', name: 'guests', component: Guests },
    { path: '/guests/:id', name: 'guest', component: Guest, props: true },
    { path: '/invite/:id', name: 'invite', component: Invitation },
    { path: '/gifts', name: 'gifts', component: GiftList },
    { path: '/songs', name: 'songs', component: Songs },
    { path: '/login', name: 'login', component: Auth },
    { path: '/photos', name: 'photos', component: Photos, meta: { requiresAuth: true } },
    { path: '*', redirect: '/' },
  ],
};
