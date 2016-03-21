import React, { Component } from 'react';
import { Breadcrumb } from 'antd';
import AppMenu from './AppMenu';
import './App.less';

class App extends Component {
  render() {
    return (
      <div className="container">
        <header className="header">
          <h2 className="website-title">权限管理系统</h2>
          <div className="user-info">用户信息</div>
        </header>
        <div className="content">
          <AppMenu selectedMenuKey={this.props.location.pathname} />
          <div className="right-container">
            <Breadcrumb separator=">" {...this.props} />
            <div className="content-area">
              {this.props.children}
            </div>
          </div>
        </div>
      </div>
    );
  }
}

App.propTypes = {
  location: React.PropTypes.object,
  children: React.PropTypes.element,
};

export default App;
