import React from 'react';
import {
  Routes,
  Route,Navigate,Router,useParams  } from 'react-router-dom';

import appInfo from './app-info';
import routes from './app-routes';

import { SideNavInnerToolbar as SideNavBarLayout } from './layouts';
import { Footer } from './components';
import { HomePage, TasksPage, ProfilePage } from './pages';
import { withNavigationWatcher ,MainNavComp} from './contexts/navigation';
import { JsxEmit } from 'typescript';
export default function Content() {

  return (
    <SideNavBarLayout title={appInfo.title}>
      
      <Routes>
        {routes.map(({ path, component }) => {
              
          let Comp = ()=> (component);
          console.log("component :",React.createElement(Comp));
          console.log("comp      :",React.createElement(component));
          return(
          <Route
            key={path}
            path={path}
            element={<MainNavComp>{component}</MainNavComp>}

          />
          
        )})}
      
        <Route path={'*'} element={<Navigate replace to="/home" />} />
      </Routes>
      <Footer>
        Copyright © 2011-{new Date().getFullYear()} {appInfo.title} Inc.
        <br />
        All trademarks or registered trademarks are property of their
        respective owners.
      </Footer>
    </SideNavBarLayout>
  );
}
