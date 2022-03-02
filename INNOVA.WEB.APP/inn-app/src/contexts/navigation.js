import React, { useState, createContext, useContext, useEffect } from 'react';
import { useLocation  } from 'react-router-dom';

const NavigationContext = createContext({});
const useNavigation = () => useContext(NavigationContext);

function NavigationProvider(props) {
  const [navigationData, setNavigationData] = useState({});

  return (
    <NavigationContext.Provider
      value={{ navigationData, setNavigationData }}
      {...props}
    />
  );
}

function withNavigationWatcher(Component) {

  
  return function (props) {
    console.log("withNavigationWatcher : ",props)
    const { path } = props.match;
    const { setNavigationData } = useNavigation();

    useEffect(() => {
      setNavigationData({ currentPath: path });
    }, [path, setNavigationData]);

    return  React.createElement(Component, props)
  }
}

const MainNavComp = ({children}) =>{
  const { pathname } = useLocation();
  const { setNavigationData } = useNavigation();

  useEffect(() => {
    setNavigationData({ currentPath: pathname });
  }, [pathname, setNavigationData]);


  console.log( "MainNavComp : :",pathname)
  return <React.Fragment>
    {React.createElement(children)}
  </React.Fragment>
}


export {
  NavigationProvider,
  useNavigation,
  withNavigationWatcher,
  MainNavComp
}
