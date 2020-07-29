import axios from 'axios';

class HttpClient {
  constructor({ uri = '', config = {} } = {}) {
    this.uri = uri;
    this.config = config;
  }

  async getAsync(resource) {
    const response = (await axios.get(this.uri + resource, this.config)).data;

    if (response.isError) {
      throw response;
    }

    return response.data;
  }

  async getAsyncS(resource) {
    const response = await axios.get(this.uri + resource, this.config);

    if (response.isError) {
      throw response;
    }

    return response.data;
  }

  async postAsync(resource, httpContent) {
    const response = (await axios.post(
      this.uri + resource,
      httpContent,
      this.config,
    )).data;

    if (response.isError) {
      throw response;
    }

    return response.data;
  }

  async postAsyncS(resource, httpContent) {
    const response = await axios.post(
      this.uri + resource,
      httpContent,
      this.config,
    );

    if (response.isError) {
      throw response;
    }

    return response.data;
  }

  async deleteAsync(resource) {
    const response = (await axios.delete(this.uri + resource, this.config))
      .data;

    if (response.isError) {
      throw response;
    }

    return response.data;
  }

  async putAsync(resource, httpContent) {
    const response = (await axios.put(
      this.uri + resource,
      httpContent,
      this.config,
    )).data;

    if (response.isError) {
      throw response;
    }

    return response.data;
  }

  async putAsyncS(resource, httpContent) {
    const response = await axios.put(
      this.uri + resource,
      httpContent,
      this.config,
    );

    if (response.isError) {
      throw response;
    }

    return response.data;
  }
}

export default HttpClient;
