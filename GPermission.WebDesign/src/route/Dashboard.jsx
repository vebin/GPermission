import React, { Component } from 'react';
import PubSub from '../common/PubSub';

const dataScore = [
  { name: '张三', gender: '男', chinese: 85, math: 98, _id: 0 },
  { name: '张三', gender: '女', chinese: 95, math: 90, _id: 1 },
  { name: '李四', gender: '男', chinese: 65, math: 48, _id: 2 },
  { name: '大妹', gender: '女', chinese: 95, math: 100, _id: 3 },
  { name: '王五', gender: '男', chinese: 75, math: 88, _id: 4 },
  { name: '赵钱', gender: '男', chinese: 75, math: 98, _id: 5 },
  { name: '二妹', gender: '女', chinese: 90, math: 98, _id: 6 },
];

class Dashboard extends Component {
  constructor(props) {
    super(props);

    this.state = {
      name: '',
      gender: 'all',
    };
  }
  componentDidMount() {
    PubSub.on('genderChange', (value) => {
      this.setState({
        gender: value,
      });
    });

    PubSub.on('nameChange', (value) => {
      this.setState({
        name: value,
      });
    });
  }
  render() {
    return (
      <div>
        <h2>学生成绩表</h2>
        <GenderFilter />
        <NameFilter />
        <ScoreTable dataScore={dataScore} name={this.state.name} gender={this.state.gender} />
      </div>
    );
  }
}

class GenderFilter extends Component {
  constructor(props) {
    super(props);

    this.handleChange = this.handleChange.bind(this);
  }
  handleChange() {
    PubSub.trigger('genderChange', this.refs.select.value);
  }
  render() {
    return (
      <p>
        <label>按性别筛选</label>
        <select onChange={this.handleChange} ref="select">
          <option value="all">All</option>
          <option value="男">男</option>
          <option value="女">女</option>
        </select>
      </p>
    );
  }
}

class NameFilter extends Component {
  constructor(props) {
    super(props);

    this.handleChange = this.handleChange.bind(this);
  }
  handleChange() {
    PubSub.trigger('nameChange', this.refs.input.value);
  }
  render() {
    return (
      <p>
        <label>按姓名筛选</label>
        <input type="text" onChange={this.handleChange} ref="input" />
      </p>
    );
  }
}

class ScoreTable extends Component {
  render() {
    return (
      <table>
        <thead>
          <tr>
            <th>姓名</th>
            <th>性别</th>
            <th>语文</th>
            <th>数学</th>
            <th>操作</th>
          </tr>
        </thead>
        <ScoreItem items={this.props.dataScore} name={this.props.name} gender={this.props.gender} />
      </table>
    );
  }
}

class ScoreItem extends Component {
  render() {
    return (
      <tbody>
        {this.props.items.map((item) => {
          if (this.props.name.length && item.name !== this.props.name) {
            return false;
          }
          if (this.props.gender !== 'all' && item.gender !== this.props.gender) {
            return false;
          }
          return (
            <tr key={item._id}>
              <td>{item.name}</td>
              <td>{item.gender}</td>
              <td>{item.chinese}</td>
              <td>{item.math}</td>
              <td>
                <a>修改</a>
                <a>删除</a>
              </td>
            </tr>
          );
        })}
      </tbody>
    );
  }
}

export default Dashboard;
