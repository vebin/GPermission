import '../common/lib';
import App from '../component/App';
import ReactDOM from 'react-dom';
import React from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';

import Dashboard from '../route/Dashboard';
import AppManager from '../route/AppManager';
import UserManager from '../route/UserManager';
import ModuleManager from '../route/ModuleManager';
import RoleManager from '../route/RoleManager';
import AuthorityManager from '../route/AuthorityManager';
import SystemSetting from '../route/SystemSetting';

ReactDOM.render(
  <Router history={hashHistory}>
    <Route path="/" breadcrumbName="仪表盘" component={App}>
      <IndexRoute component={Dashboard} />
      <Route path="user-manager" breadcrumbName="用户管理" component={UserManager} />
      <Route path="module-manager" breadcrumbName="模块管理" component={ModuleManager} />
      <Route path="role-manager" breadcrumbName="角色管理" component={RoleManager} />
      <Route path="authority-manager" breadcrumbName="权限管理" component={AuthorityManager} />
      <Route path="app-manager" breadcrumbName="应用系统" component={AppManager} />
      <Route path="system-setting" breadcrumbName="系统设置" component={SystemSetting} />
    </Route>
  </Router>, document.getElementById('react-content'));
